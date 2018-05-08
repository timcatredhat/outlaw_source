using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy_fadeout : MonoBehaviour {

	private static bool created = false; //was the object created already

	void Awake() {
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
	}
}
