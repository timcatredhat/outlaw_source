using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class break_barrier : MonoBehaviour {

	void Start () {
		if (GameObject.Find ("axe_prompt") != null) {
			GameObject.Find ("axe_prompt").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("axe_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "player_main") {
			if (GameObject.Find ("game_stats").GetComponent<game_stats> ().has_axe) {
				if (gameObject.name == "Barrier") {
					GameObject.Find ("game_stats").GetComponent<game_stats> ().barrier_down = true;
				} 
				if (gameObject.name == "Barrier2") {
					GameObject.Find ("game_stats").GetComponent<game_stats> ().barrier_2_down = true;
				}

				Destroy (gameObject, 0.01f);
			} else {
				if (GameObject.Find ("axe_prompt") != null) {
					GameObject.Find ("axe_prompt").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("axe_ui_2").GetComponent<SpriteRenderer> ().enabled = true;
				}
			}
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (GameObject.Find ("axe_prompt") != null) {
			GameObject.Find ("axe_prompt").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("axe_ui_2").GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
