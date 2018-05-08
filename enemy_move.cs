using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour {

	public string move_dir; //the direction the enemy is moving
	public float speed;

	public void Start () {
		move_dir = "right";
	}

	public void Update () {
		move ();
	}

	void move() {
		if (move_dir == "down") {
			gameObject.transform.Translate (Vector3.down * speed * Time.deltaTime);
		} else if (move_dir == "up") {
			gameObject.transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (move_dir == "right") {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (move_dir == "left") {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			gameObject.transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
	}
}