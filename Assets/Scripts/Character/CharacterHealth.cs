using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

	public float initialHealth;

	private CharacterDefense characterDefense;
	private float curHealth;

	// Use this for initialization
	void Start () {
		curHealth = initialHealth;
		characterDefense = GetComponent<CharacterDefense> ();
	}

	// Update is called once per frame
	void Update () {
		if (isCharacterDead ()) {
			//Character is dead
			Debug.Log("Character is dead");
		}
	}

	//Will return true if inclicted damage killed character
	public bool inflictDamage(float damage){
		float adjustedDamage = adjustDamage (damage);
		curHealth -= adjustedDamage;
		return isCharacterDead ();
	}

	private float adjustDamage(float damage){
		return damage - characterDefense.getDefense();
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
