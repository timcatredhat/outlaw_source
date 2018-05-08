using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gold_key_pick_up : MonoBehaviour {

	public GameObject player; //the player
	public bool placeininventory, got_key_ui; //put object in UI box at screen top; indicator of whether key is in possession or not
	public Vector3 orig_scale; //original scale of object
	public bool created = false; //is the thing created yet
	public bool close_enough = false; //are you close to the key?
	public AudioSource item_pickup; //fx


//	void Awake () {
//		if (!created) {
//			DontDestroyOnLoad (this.gameObject.transform.parent.gameObject);
//			created = true;
//		}
//	}

	void Start () {
		player = GameObject.Find ("player_main");
		placeininventory = false;
		got_key_ui = false;
		orig_scale = gameObject.transform.localScale;
	}

	void Update () {

		item_pickup = GameObject.Find ("item_audio").GetComponent<AudioSource> ();


		player = GameObject.Find ("player_main");
		if (SceneManager.GetActiveScene ().name == "foyer" && !GameObject.Find("game_stats").GetComponent<game_stats>().keepgoldkey) {
			if (close_enough && gameObject.GetComponent<SpriteRenderer> ().enabled && !placeininventory) {
				item_pickup.Play ();
				gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 10000; //make it visible above all layers
				gameObject.tag = "Untagged"; //make it always visible once taken
				gameObject.transform.Rotate (0, 0, 58.2f);
				gameObject.transform.localScale = orig_scale / 1f;
				placeininventory = true;

				Destroy (GameObject.Find ("hint_map"));

			}
			if (got_key_ui) {
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, GameObject.Find ("key_spot").transform.position, 10f * Time.deltaTime);
			}
			if ((placeininventory && !got_key_ui)) {
				GameObject.Find ("game_stats").GetComponent<game_stats> ().has_key = true; //update overall stats saying player has key
				GameObject.Find ("game_stats").GetComponent<game_stats> ().score += 20;
				got_key_ui = true;
				GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} else if (!placeininventory && !GameObject.Find ("game_stats").GetComponent<game_stats> ().keepgoldkey) {
				GameObject.Find ("game_stats").GetComponent<game_stats> ().has_key = false;
				GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = false;
				if (GameObject.Find ("game_stats").GetComponent<game_stats> ().score >= 20) {
					GameObject.Find ("game_stats").GetComponent<game_stats> ().score -= 20;
				}
			} else {
				GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = true;
			}
		} else if (!GameObject.Find("game_stats").GetComponent<game_stats>().keepgoldkey) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, GameObject.Find ("key_spot").transform.position, 10f * Time.deltaTime);
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("gold_key_ui").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().keepgoldkey) {
			Destroy (gameObject, 0.2f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "player_main") {
			close_enough = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.name == "player_main") {
			close_enough = false;
		}
	}
}
