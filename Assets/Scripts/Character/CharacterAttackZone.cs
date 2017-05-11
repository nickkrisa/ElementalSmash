using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackZone : MonoBehaviour {

	CharacterAttack characterAttack;
	// Use this for initialization
	void Start () {
		characterAttack = GetComponentInParent<CharacterAttack> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		CharacterHealth otherCharacterHealth;
		if ((otherCharacterHealth = other.GetComponent<CharacterHealth> ()) != null) {
			otherCharacterHealth.decreaseStat (characterAttack.getStat ());
		}
	}
}
