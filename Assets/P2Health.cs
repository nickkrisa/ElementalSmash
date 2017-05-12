using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Health : MonoBehaviour {

	private GameObject p2;
	private int p2Index;
	private float p2Health;
	Text health;

	// Use this for initialization
	void Start () {
		p2Index = PlayerPrefs.GetInt ("FighterType2");
		health = GetComponent<Text>();

		if (p2Index == 0) {
			p2 = GameObject.Find ("FlameCharacter");
		}
		else if (p2Index == 1) {
			p2 = GameObject.Find ("AirCharacter");
		}
		else if (p2Index == 2) {
			p2 = GameObject.Find ("EarthCharacter");
		}
		else {
			p2 = GameObject.Find ("WaterCharacter");
		}
	}

	// Update is called once per frame
	void Update () {
		p2Health = p2.GetComponent<CharacterHealth> ().curHealth;
		health.text = p2Health + "%";
	}
}
