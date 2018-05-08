using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade_out_level : MonoBehaviour {

	public bool fade_in, fade_out; //self explanatory

	void Start () {
		//gameObject.GetComponent<CanvasGroup> ().alpha = 0; //start blank
		fade_in = false; fade_out = false;
	}
	
	void Update () {
		if (fade_out && gameObject.GetComponent<CanvasGroup> ().alpha < 1) {
			gameObject.GetComponent<CanvasGroup> ().alpha += 1f;
		}
		if (gameObject.GetComponent<CanvasGroup> ().alpha >= 0.99) {
			fade_out = false;
			fade_in = true;
		}
		if (fade_in && gameObject.GetComponent<CanvasGroup> ().alpha > 0) {
			gameObject.GetComponent<CanvasGroup> ().alpha -= 0.05f;
		}
		if (gameObject.GetComponent<CanvasGroup> ().alpha <= 0.01) {
			fade_in = false;
		}
	}
}
