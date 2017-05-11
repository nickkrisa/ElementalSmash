using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefense : MonoBehaviour, ICharacterStat {

	public float initialDefense;

	private float defense;

	void Start(){
		this.defense = initialDefense;
	}

	public float increaseStat(float defenseIncreaseAmount){
		this.defense += defenseIncreaseAmount;
		return this.defense;
	}

	public float decreaseStat(float defenseDecreaseAmount){
		this.defense -= defenseDecreaseAmount;
		return this.defense;
	}

	public float getStat(){
		return this.defense;
	}
}
