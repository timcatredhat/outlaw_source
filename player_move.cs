using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour {

	public float speed;
	public string facing; //the most recent direction the player is facing
	public bool fade_in_done = false; //for fading in the stage

	void Start () {

		GameObject.Find ("fadeout_object").GetComponent<CanvasGroup> ().alpha = 1;

//		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back) {
//			if (SceneManager.GetActiveScene ().name == "foyer" && GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_foyer != Vector3.zero) {
//				gameObject.transform.position = GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_foyer;
//			} else if (SceneManager.GetActiveScene ().name == "atrium" && GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_atrium != Vector3.zero) {
//				gameObject.transform.position = GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_atrium;
//			} else if (SceneManager.GetActiveScene ().name == "hall" && GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_hall != Vector3.zero) {
//				gameObject.transform.position = GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_hall;
//			} else if (SceneManager.GetActiveScene ().name == "pool" && GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_pool != Vector3.zero) {
//				gameObject.transform.position = GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_pool;
//			}
//		} else {
			if (SceneManager.GetActiveScene ().name == "atrium") {
			if (GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before == "hall") {
				gameObject.transform.position = GameObject.Find ("back_door_1").transform.position;
			} else if (GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before == "pool") {
				gameObject.transform.position = GameObject.Find ("back_door_2").transform.position;
			} else if (GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before == "garden") {
				gameObject.transform.position = GameObject.Find ("back_door_3").transform.position;
			} else if (GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before == "foyer") {
				gameObject.transform.position = GameObject.Find ("front_door").transform.position;

			}
			} else {
				if (GameObject.Find ("game_stats").GetComponent<game_stats> ().front_door) {
					gameObject.transform.position = GameObject.Find ("front_door").transform.position;
				} else if (GameObject.Find ("game_stats").GetComponent<game_stats> ().back_door) {
					gameObject.transform.position = GameObject.Find ("back_door").transform.position;
				}
			}
	//	}
		GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
		facing = "right";
	}

	void Update () {

		if (GameObject.Find ("fadeout_object").GetComponent<CanvasGroup> ().alpha > 0 && !fade_in_done) {
			GameObject.Find ("fadeout_object").GetComponent<CanvasGroup> ().alpha -= 0.005f;
		} else {
			fade_in_done = true;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) { //for moving left
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
			facing = "left";
		} else if (Input.GetKey (KeyCode.RightArrow)) { //for moving right
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
			facing = "right";
		} 
		if (Input.GetKey (KeyCode.UpArrow)) { //for moving up
			transform.Translate (Vector3.up * speed * Time.deltaTime);
			facing = "up";
		} else if (Input.GetKey (KeyCode.DownArrow)) { //for moving down
			transform.Translate (Vector3.down * speed * Time.deltaTime);
			facing = "down";
		}
	}
}
