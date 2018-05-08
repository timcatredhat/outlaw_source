using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dark_mode : MonoBehaviour {

	private CanvasGroup dark_mode_canvas, dark_mode_canvas_top; //the overlay screens for when dark mode is activated
	private bool dark_mode_yes; //true if dark mode is on, false otherwise
	private float slowspeed, normspeed; //the speeds of the player if in dark mode or not
	private GameObject[] hidden_objects; //all hidden objects
	private bool can_exit; //can you turn off dark mode? if you're over water you can't
	public AudioSource dark_audio; //fx

	void Start () {
		dark_mode_canvas = GameObject.Find ("dark_mode_overlay").GetComponent<CanvasGroup> ();
		dark_mode_canvas_top = GameObject.Find ("dark_mode_overlay_2").GetComponent<CanvasGroup> ();
		dark_mode_yes = false;
		normspeed = gameObject.GetComponent<player_move> ().speed;
		slowspeed = normspeed / 2.05f;
		hidden_objects = GameObject.FindGameObjectsWithTag ("hidden_object");
		can_exit = true;
	}
	
	void Update () {

		dark_audio = GameObject.Find ("dark_audio").GetComponent<AudioSource> ();

		hidden_objects = GameObject.FindGameObjectsWithTag ("hidden_object");
		slow_player ();
		show_objects (); //to show the hidden stuff or not
		if (Input.GetKeyDown (KeyCode.X) && can_exit) { //turns on/off dark mode when x is pressed
			dark_audio.Play();
			dark_mode_yes = !dark_mode_yes; //the toggle
		}
		if (dark_mode_yes && dark_mode_canvas.alpha != 1) { //fade in the mode
			dark_mode_canvas.alpha += 0.99f;
			dark_mode_canvas_top.alpha += 0.99f;
		} else if (!dark_mode_yes && dark_mode_canvas.alpha != 0) { //fade out the mode
			dark_mode_canvas.alpha -= 0.09f;
			dark_mode_canvas_top.alpha -= 0.09f;
		}

		if (SceneManager.GetActiveScene ().name == "pool") {
			if (dark_mode_yes) {
				GameObject.Find ("Water_norm").GetComponent<Collider2D> ().enabled = false;
				GameObject.Find ("pool_pathway").GetComponent<Renderer> ().enabled = true; 
				GameObject.Find ("pool_pathway_2").GetComponent<Renderer> ().enabled = true; 
				GameObject.Find ("Water_hidden").GetComponent<Collider2D> ().enabled = true;
			} else {
				GameObject.Find ("Water_norm").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find ("pool_pathway").GetComponent<Renderer> ().enabled = false; 
				GameObject.Find ("pool_pathway_2").GetComponent<Renderer> ().enabled = false; 
				GameObject.Find ("Water_hidden").GetComponent<Collider2D> ().enabled = false;
			}
		}
	}

	void slow_player() {
		if (dark_mode_yes) {
			gameObject.GetComponent<player_move> ().speed = slowspeed;
		} else {
			gameObject.GetComponent<player_move> ().speed = normspeed;
		}
	}

	void show_objects() {
		hidden_objects = GameObject.FindGameObjectsWithTag ("hidden_object");
		if (dark_mode_yes) {
			foreach (GameObject h_o in hidden_objects) {
				h_o.GetComponent<SpriteRenderer> ().enabled = true; //show all objects originally hidden 
			}
		} else {
			foreach (GameObject h_o in hidden_objects) {
				h_o.GetComponent<SpriteRenderer> ().enabled = false; //hide all objects showing that are supposed to be hidden 
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "pool_pathway" || col.name == "pool_pathway_2") {
			can_exit = false;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.name == "pool_pathway" || col.name == "pool_pathway_2") {
			can_exit = true;
		}
	}
}
