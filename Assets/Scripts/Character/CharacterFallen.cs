using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFallen : MonoBehaviour {

	public float fallenDistance;
	private Vector3 startLocation;
	// Use this for initialization
	void Start () {
		startLocation = gameObject.transform.position;
		if (fallenDistance == 0) {
			fallenDistance = 100;
			Debug.Log ("Make sure to place a positive fallen distance. Defaulting to 100");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (gameObject.transform.position, startLocation) > fallenDistance) {
			CharacterHealth characterHealth = GetComponent<CharacterHealth> ();
			characterHealth.curHealth = -50;
		}
	}
}
