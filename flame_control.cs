using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame_control : MonoBehaviour {

	private bool flame; //make the fire appear to move

	void Start () {
		flame = false;
		InvokeRepeating ("fire_move", 0f, 0.13f); //make the fire appear to move
	}

	void Update() {
		if (flame) {
			GameObject.Find ("flame").GetComponent<Renderer> ().enabled = true; //make flame
		//	GameObject.Find ("Water").GetComponent<Renderer> ().enabled = false;
		} else {
			GameObject.Find ("flame").GetComponent<Renderer> ().enabled = false; //make flame (second scene)
		//	GameObject.Find ("Water").GetComponent<Renderer> ().enabled = true;
		}
	}

	void fire_move() {
		flame = !flame;
	}
}
