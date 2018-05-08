using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class through_door : MonoBehaviour {

	public string facing_direction; //the orientation of the player going through the door

	void Awake () {
		GameObject.Find ("gold_key_prompt").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("gold_key_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_prompt").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
	}

	void Update () {
		facing_direction = GameObject.Find ("player_main").GetComponent<player_move> ().facing;
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "player_main") {

			if (!GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door) {

				GameObject.Find ("door_opening").GetComponent<AudioSource> ().Play ();

				GameObject.Find ("game_stats").GetComponent<game_stats> ().front_door = true;
				GameObject.Find ("game_stats").GetComponent<game_stats> ().back_door = false;

				if (SceneManager.GetActiveScene ().name == "foyer" && facing_direction == "up") {
					if (GameObject.Find ("game_stats").GetComponent<game_stats> ().has_key) {
						GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_foyer = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.1f, 0);
						GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
						facing_direction = "down";
						GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before = "foyer";
						next_scene ("atrium");
					} else {
						GameObject.Find ("gold_key_prompt").GetComponent<SpriteRenderer> ().enabled = true;
						GameObject.Find ("gold_key_ui_2").GetComponent<SpriteRenderer> ().enabled = true;
					}
				} else if (SceneManager.GetActiveScene ().name == "atrium" && facing_direction == "up") {
					if (GameObject.Find ("player_main").transform.position.x <= -1.144f) {
						GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_atrium = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.1f, 0);
						GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before = "hall";
						next_scene ("hall");
					} else if (GameObject.Find ("player_main").transform.position.x > -1.144f && GameObject.Find ("player_main").transform.position.x <= -0.184f) {
						GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_atrium = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.1f, 0);
						GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
						GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before = "pool";
						next_scene ("pool");
					} else if (GameObject.Find ("player_main").transform.position.x > -0.184f) {
						if (GameObject.Find ("game_stats").GetComponent<game_stats> ().has_key_2) {
							GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
							GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_atrium = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.05f, 0);
							GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
							GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
							GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before = "garden";
							next_scene ("garden");
						} else {
							GameObject.Find ("green_key_prompt").GetComponent<SpriteRenderer> ().enabled = true;
							GameObject.Find ("green_key_ui_2").GetComponent<SpriteRenderer> ().enabled = true;
						}
					}
				} else if (SceneManager.GetActiveScene ().name == "hall" && facing_direction == "left") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_hall = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.1f, 0);
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("basement");
				} else if (SceneManager.GetActiveScene ().name == "pool" && facing_direction == "up") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().last_door_pool = GameObject.Find ("player_main").transform.position + new Vector3 (0, -0.12f, 0);
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = false;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("balcony");
				}
			}
		}
	}
		

	void OnCollisionExit2D(Collision2D col) {
		GameObject.Find ("gold_key_prompt").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("gold_key_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_prompt").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
	}

	void next_scene(string level) { //load next scene with delay so no teleporting
		//yield return new WaitForSeconds(0.4f);
		SceneManager.LoadScene (level);
	}
}
