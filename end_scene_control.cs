using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end_scene_control : MonoBehaviour {

	public int total_score;

	void Awake () {
		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().player_health <= 0.01f) {
			Destroy (GameObject.Find ("escaped"));
		} else {
			Destroy (GameObject.Find ("busted"));
		}
	}

	void Start () {

		if (GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins > PlayerPrefs.GetInt("hiscore", 0)) {
			PlayerPrefs.SetInt ("hiscore", GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins);
		}

		total_score = GameObject.Find ("game_stats").GetComponent<game_stats> ().score + GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins;
		GameObject.Find ("score_text").GetComponent<Text> ().text = "score: " + total_score.ToString ();
		GameObject.Find ("high_score_text").GetComponent<Text> ().text = "highest: " + PlayerPrefs.GetInt("hiscore", 0).ToString ();

	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

			GameObject.Find("game_stats").GetComponent<game_stats>().restart();

			SceneManager.LoadScene ("main_menu");
		}
		
	}
}
