using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_ui : MonoBehaviour {

	public Text score_text; //the ui score on screen
	public bool changing_score; //freezes update on temp while ui updates on screen
	public int temp_score; //last score recorded

	void Start () {
		score_text = gameObject.GetComponent<Text> ();
		changing_score = false;
		temp_score = GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins; //last score recorded
	}
	
	void Update () {
		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins >= temp_score) {
			changing_score = true;
			score_text.text = "score: " + temp_score.ToString ();
			temp_score += 1;
		} else {
			changing_score = false;
		}

		if (!changing_score) {
			temp_score = GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins; //last score recorded
		}
	}
}