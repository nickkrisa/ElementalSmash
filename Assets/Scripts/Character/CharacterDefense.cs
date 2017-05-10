using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefense : MonoBehaviour {

	public float initialDefense;

	private float defense;

	void Start(){
		this.defense = initialDefense;
	}

	public float addDefense(float defenseIncreaseAmount){
		this.defense += defenseIncreaseAmount;
		return this.defense;
	}

	public float removeDefense(float defenseDecreaseAmount){
		this.defense -= defenseDecreaseAmount;
		return this.defense;
	}

	public float getDefense(){
		return this.defense;
	}
}
