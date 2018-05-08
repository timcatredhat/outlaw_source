using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_screen_control : MonoBehaviour {

	public bool pause_menu_on = false; //are you on the pause menu?
	public bool first_text = true; //are you on the main pause menu or the control screen?
	public bool ready; //prevent enter from doubling up and running through pause menu

	void Awake () {
		gameObject.GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 0;
	}
	
	void Update () {
		if ((Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) && !pause_menu_on) {
			gameObject.GetComponent<Canvas> ().enabled = true;
			pause_menu_on = true;
			Time.timeScale = 0;
		}

		if (!pause_menu_on) {
			gameObject.GetComponent<Canvas> ().enabled = false;
			Time.timeScale = 1;
		}
	}
}
