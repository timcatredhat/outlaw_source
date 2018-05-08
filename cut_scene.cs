using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cut_scene : MonoBehaviour {

	public bool fade = false;
	public bool talk1done, talk2done, talk3done; //is the screen spitting out words?
	public Text d1, d2, d3; //the three lines
	public string m1, m2, m3; //the strings
	public bool y1, y2, y3; //control coroutine

	void Awake() {
		GameObject.Find ("full_thing_1").GetComponent<Text> ().enabled = false;
		GameObject.Find ("full_thing_2").GetComponent<Text> ().enabled = false;

	}

	void Start () {
		d1 = GameObject.Find ("title1").GetComponent<Text>();
		d2 = GameObject.Find ("title2").GetComponent<Text>();
		d3 = GameObject.Find ("title3").GetComponent<Text>();
		m1 = "the king's palace";
		m2 = "is full of gold.";
		m3 = "take it all.";
		d1.text = ""; d2.text = ""; d3.text = "";
		talk1done = false; talk2done = false; talk3done = false;
		y1 = true; y2 = false; y3 = false;
//		StartCoroutine (talkone ());
//		StartCoroutine (talktwo ());
	}

	void FixedUpdate() {
		if (y1) {
			StartCoroutine (talkone ());
		} else if (y2) {
			StartCoroutine (talktwo ());
		} else if (y3) {
			StartCoroutine (talkthree ());
		}
	}

	void Update () {



		if (fade) {
			GameObject.Find ("fade").GetComponent<CanvasGroup> ().alpha += 0.05f;
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			GameObject.Find ("menu_select").GetComponent<AudioSource> ().Play ();

			fade = true;
			SceneManager.LoadScene ("foyer");
		}
	}

	public IEnumerator talkone() {
		y1 = false;

		if (!talk1done) {
			foreach (char letter in m1.ToCharArray()) { //animates the typing of the characters in dialogue on the screen
				d1.text += letter;
				yield return new WaitForSeconds (0.045f);
			}
		}
		talk1done = true;
		y2 = true;
	}

	public IEnumerator talktwo() {
		y2 = false;

		if (talk1done) {
			
			yield return new WaitForSeconds (0.01f);
			if (!talk2done) {
				foreach (char letter in m2.ToCharArray()) { //animates the typing of the characters in dialogue on the screen
					d2.text += letter;
					yield return new WaitForSeconds (0.045f);
				}
			}
			talk2done = true;
			y3 = true;
		}
	}

	public IEnumerator talkthree() {
		y3 = false;

		if (talk2done) {
			yield return new WaitForSeconds (0.6f);
			if (!talk3done) {
				foreach (char letter in m3.ToCharArray()) { //animates the typing of the characters in dialogue on the screen
					d3.text += letter;
					yield return new WaitForSeconds (0.045f);
				}
			}
			talk3done = true;
		}
	}
}
