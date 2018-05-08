using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_spawn_loc : MonoBehaviour {

	public GameObject[] key_spawn_locations; //array of all possible spawn locations for key
	public int rand_location; //integer of random location in array above

	void Awake () {
		key_spawn_locations = GameObject.FindGameObjectsWithTag ("spawn_spot_key");
		rand_location = Random.Range (0, key_spawn_locations.Length);
		gameObject.transform.position = key_spawn_locations [rand_location].transform.position;
	}
}