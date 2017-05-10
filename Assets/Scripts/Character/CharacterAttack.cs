using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {

	public float initialAttack;

	private float attack;

	void Start(){
		this.attack = initialAttack;
	}

	public float addAttack(float attackIncreaseAmount){
		this.attack += attackIncreaseAmount;
		return this.attack;
	}

	public float removeAttack(float attackDecreaseAmount){
		this.attack -= attackDecreaseAmount;
		return this.attack;
	}

	public float getAttack(){
		return this.attack;
	}
}
