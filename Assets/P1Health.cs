using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Health : MonoBehaviour {

	private GameObject p1;
	private int p1Index;
	private float p1Health;
	Text health;

	// Use this for initialization
	void Start () {
		p1Index = PlayerPrefs.GetInt ("FighterType1");
		health = GetComponent<Text>();

		if (p1Index == 0) {
			p1 = GameObject.Find ("FlameCharacter");
		}
		else if (p1Index == 1) {
			p1 = GameObject.Find ("AirCharacter");
		}
		else if (p1Index == 2) {
			p1 = GameObject.Find ("EarthCharacter");
		}
		else {
			p1 = GameObject.Find ("WaterCharacter");
		}
	}
	
	// Update is called once per frame
	void Update () {
		p1Health = p1.GetComponent<CharacterHealth> ().curHealth;
		health.text = p1Health + "%";
	}
}
