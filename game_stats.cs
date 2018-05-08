using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_stats : MonoBehaviour {

	public bool has_key, has_key_2, has_axe, has_trophy; //did the player get the foyer key? did the player get the green key? did the player get the axe?
	public int score = 0, score_coins = 0; //player score from objects, from coins
	private static bool created = false; //to prevent duplicates
	public Vector3 last_door_foyer, last_door_atrium, last_door_hall, last_door_pool; //the location of the doors the player latest went through in each level
	public bool keepgoldkey, keepaxe, keepgreenkey, keeptrophy; //lets game know if you got the stuff in the respective stage and progressed. if so, keep it no matter what
	public string latest_scene; //the latest scene unlocked. used for respawning.
	public bool going_back = false; //loading scene where to place player... if going back from another room, diff placement
	public float player_health; //the updated player health
	public bool opening_door; //make sure you can't portal
	public bool barrier_down, barrier_2_down; //is the barrier broken
	public bool front_door, back_door; //was the player most recently through a front or back door?
	public string scene_before; //the lagging id of the scene before this one... for atrium doors
	public string player_name; //for the last end scene
	public List<string> coin_kill_list; //kills all coins already caught on reload scene

	void Awake () {
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
		keepgoldkey = false;
		keepaxe = false;
		keepgreenkey = false;
		keeptrophy = false;
		latest_scene = "foyer";
		player_health = 1;
		opening_door = false;
		barrier_down = false;
		barrier_2_down = false;

		front_door = true; back_door = false;
	}

	void Start () {
		has_key = false;
		has_key_2 = false;
		has_axe = false;
		has_trophy = false;
		score = 0;
		score_coins = 0;
		coin_kill_list.Clear ();

		GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("trophy_ui").GetComponent<SpriteRenderer> ().enabled = false;

	}

	public void restart() {
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
		keepgoldkey = false;
		keepaxe = false;
		keepgreenkey = false;
		keeptrophy = false;
		latest_scene = "foyer";
		player_health = 1;
		opening_door = false;
		barrier_down = false;
		barrier_2_down = false;

		front_door = true; back_door = false;
		has_key = false;
		has_key_2 = false;
		has_axe = false;
		has_trophy = false;
		score = 0;
		score_coins = 0;
		coin_kill_list.Clear ();

		GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("green_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("trophy_ui").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	void Update () {

		if (SceneManager.GetActiveScene ().name == "end_game") {
			GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("green_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("trophy_ui").GetComponent<SpriteRenderer> ().enabled = false;

		}

		if (SceneManager.GetActiveScene ().name == "main_menu" || SceneManager.GetActiveScene ().name == "cut_scene" || SceneManager.GetActiveScene ().name == "end_game") {
			if (GameObject.Find ("player_health_canvas") != null) {
				GameObject.Find ("player_health_canvas").GetComponent<Canvas> ().enabled = false;
			} 
		} else if (GameObject.Find ("player_main") != null && GameObject.Find ("pause_screen").GetComponent<Canvas> ().enabled) {
				GameObject.Find ("player_health_canvas").GetComponent<Canvas> ().enabled = false;
		} else {
			GameObject.Find ("player_health_canvas").GetComponent<Canvas> ().enabled = true;
		}

		if (coin_kill_list != null) {
			foreach (string s in coin_kill_list) {
				Destroy (GameObject.Find(s));
			}
		}

		if (SceneManager.GetActiveScene ().name != "end_game" && SceneManager.GetActiveScene ().name != "main_menu") {

			if (player_health <= 0.0001f) {
				SceneManager.LoadScene ("end_game"); //end game when player loses
			}

			if (!has_key) {
				score = 0;
			}

			if (SceneManager.GetActiveScene ().name == "atrium") {
				latest_scene = "atrium";
			}

			if (SceneManager.GetActiveScene ().name == "atrium" && !keepgoldkey) {
				has_key = true;
				keepgoldkey = true;
				latest_scene = "atrium";
			}

			if (SceneManager.GetActiveScene ().name == "pool" && has_key_2) {
				keepgreenkey = true;
				latest_scene = "pool";
			}

			if (has_trophy && SceneManager.GetActiveScene ().name == "atrium") {
				keeptrophy = true;
			}

			if (SceneManager.GetActiveScene ().name == "hall") {
				latest_scene = "hall";
			}
			if (SceneManager.GetActiveScene ().name == "basement") {
				latest_scene = "basement";
			}
			if (SceneManager.GetActiveScene ().name == "pool") {
				latest_scene = "pool";
			}
			if (SceneManager.GetActiveScene ().name == "balcony") {
				latest_scene = "balcony";
			}
			if (SceneManager.GetActiveScene ().name == "garden") {
				latest_scene = "garden";
			}
			if (SceneManager.GetActiveScene ().name == "foyer") {
				latest_scene = "foyer";
			}
			if (SceneManager.GetActiveScene ().name == "hall" && has_axe) {
				keepaxe = true;
				latest_scene = "hall";
			}

			if (keepgoldkey) {
				GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} 
//			else if (!keepgoldkey) {
//				GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
//			}

			if (keepaxe) {
				GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} 
//			else if (!keepaxe) {
//				GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = false;
//			}

			if (keepgreenkey) {
				GameObject.Find ("green_key_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} 
//			else if (!keepgreenkey) {
//				GameObject.Find ("green_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
//			}

			if (keeptrophy) {
				GameObject.Find ("trophy_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} 
//			else if (!keeptrophy) {
//				GameObject.Find ("trophy_ui").GetComponent<SpriteRenderer> ().enabled = false;
//			}

			if (opening_door) {
				StartCoroutine (door_cool ());
			}

			if (barrier_down) {
				if (GameObject.Find ("Barrier") != null) {
					Destroy (GameObject.Find ("Barrier"));
				}
			}

			if (barrier_2_down) {
				if (GameObject.Find ("Barrier2") != null) {
					Destroy (GameObject.Find ("Barrier2"));
				}
			}

		}

		if (SceneManager.GetActiveScene ().name == "cut_scene") {
//			GameObject.Find ("menu").GetComponent<cut_scene> ().y1 = true; 
//			GameObject.Find ("menu").GetComponent<cut_scene> ().y2 = false; 
//			GameObject.Find ("menu").GetComponent<cut_scene> ().y3 = false; 
//			GameObject.Find ("menu").GetComponent<cut_scene> ().talk1done = false; 
//			GameObject.Find ("menu").GetComponent<cut_scene> ().talk2done = false; 
//			GameObject.Find ("menu").GetComponent<cut_scene> ().talk3done = false; 

			GameObject.Find ("full_thing_1").GetComponent<Text> ().enabled = true;
			GameObject.Find ("full_thing_2").GetComponent<Text> ().enabled = true;

		}
	}

	IEnumerator door_cool() { //prevent collision teleportation
		opening_door = true;
		yield return new WaitForSeconds (0.2f);
		opening_door = false;
	}
}
