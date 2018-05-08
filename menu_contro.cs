using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_contro : MonoBehaviour {


	public bool pause_menu_on = false; //are you on the pause menu?
	public bool first_text = true; //are you on the main pause menu or the control screen?
	public bool ready; //prevent enter from doubling up and running through pause menu

	void Awake () {
		GameObject.Find ("first_text").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.Find ("control_screen").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.Find ("fade").GetComponent<CanvasGroup> ().alpha = 0;
	}

	void Start() {
		GameObject.Find ("soundtrack").GetComponent<AudioSource> ().Play ();
	}

}
