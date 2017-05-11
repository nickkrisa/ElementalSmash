using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour, ICharacterStat {

	public float initialAttack;

	private float attack;

	void Start(){
		this.attack = initialAttack;
	}

	public float increaseStat(float attackIncreaseAmount){
		this.attack += attackIncreaseAmount;
		return this.attack;
	}

	public float decreaseStat(float attackDecreaseAmount){
		this.attack -= attackDecreaseAmount;
		return this.attack;
	}

	public float getStat(){
		return this.attack;
	}
}
