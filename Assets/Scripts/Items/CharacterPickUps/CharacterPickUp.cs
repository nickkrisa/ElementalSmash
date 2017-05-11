using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickUp : MonoBehaviour {

	public float statChangeAmount;
	public bool isBeneficial;

	public string statsScriptName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		ICharacterStat characterStat;
		if ((characterStat = other.gameObject.GetComponent (statsScriptName) as ICharacterStat) != null) {
			if (isBeneficial) {
				characterStat.increaseStat (statChangeAmount);
			} else {
				characterStat.decreaseStat (statChangeAmount);
			}
			Destroy (this.gameObject);
		}
	}
}
