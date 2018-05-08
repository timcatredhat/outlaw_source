using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class axe_pickup : MonoBehaviour {

	public GameObject player; //the player
	public bool placeininventory, got_axe_ui; //put object in UI box at screen top; indicator of whether axe is in possession or not
	public Vector3 orig_scale; //original scale of object
	public bool created = false; //is the thing created yet
	public bool close_enough = false; //are you close to the axe?
	public AudioSource item_pickup; //fx

	void Start () {
		player = GameObject.Find ("player_main");
		placeininventory = false;
		got_axe_ui = false;
		orig_scale = gameObject.transform.localScale;
	}

	void Update () {

		item_pickup = GameObject.Find ("item_audio").GetComponent<AudioSource> ();

		player = GameObject.Find ("player_main");
		if (SceneManager.GetActiveScene ().name == "basement" && !GameObject.Find("game_stats").GetComponent<game_stats>().keepaxe) {
			if (close_enough && gameObject.GetComponent<SpriteRenderer> ().enabled && !placeininventory) {
				item_pickup.Play ();
				gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 10000; //make it visible above all layers
				gameObject.tag = "Untagged"; //make it always visible once taken
				gameObject.transform.localScale = orig_scale / 1.1f;
				placeininventory = true;

				Destroy (GameObject.Find ("hint_map"));

			}
			if (got_axe_ui) {
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, GameObject.Find ("axe_spot").transform.position, 10f * Time.deltaTime);
			}
			if ((placeininventory && !got_axe_ui)) {
				GameObject.Find ("game_stats").GetComponent<game_stats> ().has_axe = true; //update overall stats saying player has axe
				GameObject.Find ("game_stats").GetComponent<game_stats> ().score += 10;
				got_axe_ui = true;
				GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = true;
			} else if (!placeininventory && !GameObject.Find ("game_stats").GetComponent<game_stats> ().keepaxe) {
				GameObject.Find ("game_stats").GetComponent<game_stats> ().has_axe = false;
				GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = false;
				if (GameObject.Find ("game_stats").GetComponent<game_stats> ().score >= 30) {
					GameObject.Find ("game_stats").GetComponent<game_stats> ().score -= 10;
				}
			} else {
				GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = true;
			}
		} else if (!GameObject.Find("game_stats").GetComponent<game_stats>().keepaxe) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, GameObject.Find ("axe_spot").transform.position, 10f * Time.deltaTime);
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("axe_ui").GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().keepaxe) {
			Destroy (gameObject, 1f);
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
