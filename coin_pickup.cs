using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_pickup : MonoBehaviour {

	public AudioSource coin_sound; //sound fx!

	void Start () {
	}
	
	void Update () {
		coin_sound = GameObject.Find ("coin_audio").GetComponent<AudioSource> ();
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "player_main" && gameObject.GetComponent<SpriteRenderer>().enabled) {
			coin_sound.Play ();
			GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins += 15;
			GameObject.Find ("game_stats").GetComponent<game_stats> ().coin_kill_list.Add (gameObject.name);
			Destroy (gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.name == "player_main" && gameObject.GetComponent<SpriteRenderer>().enabled) {
			coin_sound.Play ();

			GameObject.Find ("game_stats").GetComponent<game_stats> ().score_coins += 15;
			GameObject.Find ("game_stats").GetComponent<game_stats> ().coin_kill_list.Add (gameObject.name);
			Destroy (gameObject);
		}
	}
}
