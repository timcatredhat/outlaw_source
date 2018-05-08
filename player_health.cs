using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_health : MonoBehaviour {

	public float health_amount; //the health amount
	public bool changing_score; //freezes update on temp while ui updates on screen
	public float temp_health; //last health recorded

	void Awake () {
		health_amount = 1;
	}

	void Start () {
		changing_score = false;
		temp_health = GameObject.Find ("game_stats").GetComponent<game_stats> ().player_health; //last score recorded
	}

	void Update () {

		GameObject.Find ("player_health_canvas").GetComponent<Canvas> ().worldCamera = Camera.main;

		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().player_health <= temp_health) {
			changing_score = true;
			health_amount = temp_health;
			gameObject.GetComponent<Image> ().fillAmount = health_amount;
			temp_health -= 0.002f;
		} else {
			changing_score = false;

		}

		if (!changing_score) {
			temp_health = GameObject.Find ("game_stats").GetComponent<game_stats> ().player_health; //last score recorded
		}
	}
		
}
