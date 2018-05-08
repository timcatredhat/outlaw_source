using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_select : MonoBehaviour {


	public int option_select = 0; //which option you're hovering over currently: 0 is controls, 1 is escape, 2 is resume
	public bool ready = false; //ready to load control
	public bool fade = false; //fade out into game
	public bool load_foyer = false; //load the foyer!

	void Awake () {
		load_foyer = false;
		fade = false;
		ready = false;
		option_select = 0;
	}

	void Update () {

		if (load_foyer) {
			SceneManager.LoadScene ("cut_scene");
		}

		if (fade) {
			GameObject.Find ("fade").GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if (GameObject.Find ("menu").GetComponent<menu_contro> ().first_text) {

			if (option_select >= 0 && option_select < 1) {
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

					option_select += 1;
					gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - 1.05f);
				}
			}
			if (option_select > 0 && option_select <= 1) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

					option_select -= 1;
					gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 1.05f);
				}
			}

			GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 1;
			GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 0;
			if (option_select == 1) {
				if (Input.GetKeyDown (KeyCode.Return)) {
					GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

					//StartCoroutine(loadscene_delay());
					loadscene_delay();
					fade = true;
				}
			} else if (option_select == 0) {
				if (Input.GetKeyDown (KeyCode.Return) && !ready) {
					GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

					//StartCoroutine (delay_load ());
					GameObject.Find ("menu").GetComponent<menu_contro> ().first_text = false;
					ready = true;
					//						GameObject.Find ("menu").GetComponent<menu_contro> ().ready = false;
					//						GameObject.Find ("menu").GetComponent<menu_contro> ().first_text = false;
				}
			}
		} else {
			GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 1;
			if (Input.GetKeyDown (KeyCode.Return) && ready) {
				GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

				GameObject.Find ("menu").GetComponent<menu_contro> ().first_text = true;
				ready = false;
			}
		}


	}

	void loadscene_delay() {
		//yield return new WaitForSeconds (0.9f);
		//SceneManager.LoadScene ("foyer");
		load_foyer = true;

	}
}
