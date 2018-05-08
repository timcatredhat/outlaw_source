using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class through_back_door : MonoBehaviour {
	
	public string facing_direction; //the orientation of the player going through the door

	void Update () {
		facing_direction = GameObject.Find ("player_main").GetComponent<player_move> ().facing;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "player_main") {
			if (!GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door) {

				GameObject.Find ("door_opening").GetComponent<AudioSource> ().Play ();

			
				GameObject.Find ("game_stats").GetComponent<game_stats> ().front_door = false;
				GameObject.Find ("game_stats").GetComponent<game_stats> ().back_door = true;

				if (SceneManager.GetActiveScene ().name == "atrium" && facing_direction == "down") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().scene_before = "foyer";

					next_scene ("foyer"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				} else if (SceneManager.GetActiveScene ().name == "hall" && facing_direction == "down") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("atrium"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				} else if (SceneManager.GetActiveScene ().name == "basement" && facing_direction == "left") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					facing_direction = "right";
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("hall"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				} else if (SceneManager.GetActiveScene ().name == "pool") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					facing_direction = "down";
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("atrium"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				} else if (SceneManager.GetActiveScene ().name == "balcony") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					facing_direction = "down";
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("pool"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				} else if (SceneManager.GetActiveScene ().name == "garden") {
					GameObject.Find ("fadeout_object").GetComponent<fade_out_level> ().fade_out = true;
					GameObject.Find ("game_stats").GetComponent<game_stats> ().going_back = true;
					facing_direction = "down";
					GameObject.Find ("game_stats").GetComponent<game_stats> ().opening_door = true;
					next_scene ("atrium"); //GameObject.Find ("game_stats").GetComponent<game_stats> ().deep_level);
				}
			}
		}
	}

	public void next_scene(string level) { //load next scene with delay so no teleporting
		//yield return new WaitForSeconds(1f);
		SceneManager.LoadScene (level);
	}
}
