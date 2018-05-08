using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_turning : MonoBehaviour {

	public string scene_name; //name of the current scene, name of the current cone direction
	public int rotation_value; //if 1, rotates clockwise, if 2, rotates ccw
	public GameObject enemy_parent; //parent object for enemy
	public AudioSource got_caught; //fx


	public void Start () {
		got_caught = GameObject.Find ("got_caught_audio").GetComponent<AudioSource> ();

		scene_name = SceneManager.GetActiveScene().name; //the name of the current scene
		enemy_parent = gameObject.transform.parent.gameObject;
	}
	
	void Update () {
		got_caught = GameObject.Find ("got_caught_audio").GetComponent<AudioSource> ();

		scene_name = SceneManager.GetActiveScene().name; //the name of the current scene
	}

	void OnCollisionEnter2D(Collision2D col) { //checks collisions with the enemy bounds
		if (col.gameObject.name == "player_main") { //game over here, restart at level
			got_caught.Play();
			GameObject.Find("game_stats").GetComponent<game_stats>().player_health -= 1/10f;
			SceneManager.LoadScene(GameObject.Find("game_stats").GetComponent<game_stats>().latest_scene);
		}
		if (enemy_parent.GetComponent<enemy_sight_cone>().active_cone == 
			enemy_parent.GetComponent<enemy_move>().move_dir) {
			 if (col.gameObject.tag == "enemy_walls") { //send out a message saying enemy hit a wall (turn next? etc)
				if (rotation_value % 2 != 0) {
					turnc (enemy_parent.GetComponent<enemy_move>().move_dir);
				} else {
					turncc (enemy_parent.GetComponent<enemy_move>().move_dir);
				}
			}
		}
	}

	public void turnc(string start_dir) { //turn enemy clockwise
		if (start_dir == "down") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "left";
		} else if (start_dir == "left") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "up";
		} else if (start_dir == "up") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "right";
		} else if (start_dir == "right") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "down";
		}
		enemy_parent.GetComponent<enemy_sight_cone> ().active_cone = enemy_parent.GetComponent<enemy_move>().move_dir;
	}

	public void turncc(string start_dir) { //turn enemy counterclockwise
		if (start_dir == "down") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "right";
		} else if (start_dir == "left") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "down";
		} else if (start_dir == "up") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "left";
		} else if (start_dir == "right") {
			enemy_parent.GetComponent<enemy_move>().move_dir = "up";
		}
		enemy_parent.GetComponent<enemy_sight_cone> ().active_cone = enemy_parent.GetComponent<enemy_move>().move_dir;
	}
}