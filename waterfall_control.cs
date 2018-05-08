using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall_control : MonoBehaviour {

	private bool water_fall; //make the water appear to move

	void Start () {
		water_fall = false;
		InvokeRepeating ("water_move", 0f, 0.13f); //make the water appear to move
	}

	void Update() {
		if (water_fall) {
			GameObject.Find ("Waterfall").GetComponent<Renderer> ().enabled = true; //make waterfall
			GameObject.Find ("Water").GetComponent<Renderer> ().enabled = false;
		} else {
			GameObject.Find ("Waterfall").GetComponent<Renderer> ().enabled = false; //make waterfall (second scene)
			GameObject.Find ("Water").GetComponent<Renderer> ().enabled = true;
		}
	}

	void water_move() {
		water_fall = !water_fall;
	}
}