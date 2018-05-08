using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crow_talk : MonoBehaviour {

	public Text crow_speech; //what it says
	public SpriteRenderer speech_bubble; //the bubble
	public CanvasGroup the_words; //the actual words
	public bool talking; //is it talking
	public List<string> sentences; //what can the crow say

	void Start () {
		crow_speech = GameObject.Find ("crow_words_text").GetComponent<Text>();
		speech_bubble = GameObject.Find ("crow_talk").GetComponent<SpriteRenderer> ();
		the_words = GameObject.Find ("crow_words").GetComponent<CanvasGroup> ();
		talking = false;
	}
	
	void Update () {

		sentences.Add ("hi"); sentences.Add ("no"); sentences.Add ("um"); sentences.Add ("ow"); sentences.Add ("yo"); sentences.Add ("!!!");
		sentences.Add ("si"); sentences.Add ("..."); sentences.Add ("??"); sentences.Add (":)"); sentences.Add (":("); sentences.Add ("zz");

		speech_bubble.enabled = false;
		the_words.alpha = 0;
		crow_speech = GameObject.Find ("crow_words_text").GetComponent<Text>();

		if (talking) {
				speech_bubble.enabled = true;
				the_words.alpha = 1;
		} else {
			speech_bubble.enabled = false;
			the_words.alpha = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "player_main") {
			picknewline (); 
			talking = true;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.name == "player_main") {
			talking = false;
		}
	}

	void picknewline() { //crow picks new thing to say
		var ra = Random.Range(0, 12);
		crow_speech.text = sentences[ra];
	}
}
