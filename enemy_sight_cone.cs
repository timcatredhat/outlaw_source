using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_sight_cone : MonoBehaviour {

	public string scene_name; //name of the current scene, name of the current cone direction
	public string orientation; //the orientation of the enemy object
	public string active_cone; //the cone that's active right now
	public GameObject cone_left, cone_up, cone_down, cone_right; //the cones of sight for the enemy
	public AudioSource got_caught; //fx

	void Start () {
		got_caught = GameObject.Find ("got_caught_audio").GetComponent<AudioSource> ();

		orientation = "down";
		active_cone = "down";
	}
	
	void Update () {
		got_caught = GameObject.Find ("got_caught_audio").GetComponent<AudioSource> ();
		scene_name = SceneManager.GetActiveScene().name; //the name of the current scene
		orientation = gameObject.GetComponent<enemy_move> ().move_dir;
		moving ();
	}

	void moving() { //cone orientation control
		if (orientation == "left") {
			cone_left.SetActive (true); //make the left cone visible
			cone_right.SetActive (false);
			cone_up.SetActive (false);
			cone_down.SetActive (false);
			active_cone = "left";
		} else if (orientation == "right") {
			cone_left.SetActive (false); //make the right cone visible
			cone_right.SetActive (true);
			cone_up.SetActive (false);
			cone_down.SetActive (false);
			active_cone = "right";
		} else if (orientation == "up") {
			cone_left.SetActive (false); //make the up cone visible
			cone_right.SetActive (false);
			cone_up.SetActive (true);
			cone_down.SetActive (false);
			active_cone = "up";
		} else if (orientation == "down") {
			cone_left.SetActive (false); //make the down cone visible
			cone_right.SetActive (false);
			cone_up.SetActive (false);
			cone_down.SetActive (true);
			active_cone = "down";
		}
	}

	void OnCollisionEnter2D(Collision2D col) { //checks collisions with the enemy bounds
		if (col.gameObject.name == "player_main") { //game over here, restart at level
			got_caught.Play();
			GameObject.Find("game_stats").GetComponent<game_stats>().player_health -= 1/10f;
			SceneManager.LoadScene(GameObject.Find("game_stats").GetComponent<game_stats>().latest_scene);
		}
	}
}