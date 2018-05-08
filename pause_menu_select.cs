using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu_select : MonoBehaviour {

	public int option_select = 0; //which option you're hovering over currently: 0 is controls, 1 is escape, 2 is resume
	public bool ready = false; //ready to load control

	void Start () {
		
	}
	
	void Update () {
		if (GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().pause_menu_on) {
			if (GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().first_text) {
				
				if (option_select >= 0 && option_select < 2) {
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

						option_select += 1;
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - 0.545f);
					}
				}
				if (option_select > 0 && option_select <= 2) {
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

						option_select -= 1;
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 0.545f);
					}
				}

				GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 1;
				GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 0;
				if (option_select == 1) {
					if (Input.GetKeyDown (KeyCode.Return)) {
						GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

						SceneManager.LoadScene ("end_game");
					}
				} else if (option_select == 2) {
					if (Input.GetKeyDown (KeyCode.Return)) {
						GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

						GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().pause_menu_on = false;
					}
				} else if (option_select == 0) {
					if (Input.GetKeyDown (KeyCode.Return) && !ready) {
						GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

						//StartCoroutine (delay_load ());
						GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().first_text = false;
						ready = true;
//						GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().ready = false;
//						GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().first_text = false;
					}
				}
			} else {
				GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 0;
				GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 1;
				if (Input.GetKeyDown (KeyCode.Return) && ready) {
					GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

					GameObject.Find ("pause_screen").GetComponent<pause_screen_control> ().first_text = true;
					ready = false;
				}
			}

		}
	}

}
