using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

	public float initialHealth;
	private float curHealth;
	// Use this for initialization
	void Start () {
		curHealth = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Will return true if inclicted damage killed character
	public bool inflictDamage(float damage){
		curHealth -= damage;
		return isCharacterDead ();
	}
	private bool isCharacterDead(){
		if (curHealth < 0) {
			return true;
		}
		return false;
	}
	public void addHealth(float hp){
		curHealth += hp;
	}
}
