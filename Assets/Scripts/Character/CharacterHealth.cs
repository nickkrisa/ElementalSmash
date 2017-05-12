using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour, ICharacterStat {

	public float initialHealth;

	private CharacterDefense characterDefense;
	public float curHealth;

	// Use this for initialization
	void Start () {
		curHealth = initialHealth;
		characterDefense = GetComponent<CharacterDefense> ();
	}

	// Update is called once per frame
	void Update () {
		if (isCharacterDead ()) {
			gameObject.SetActive (false);
			Debug.Log("Character " + gameObject.name +" is dead.");
            //when one player dies, the other wins, and game goes to endscene
            SceneManager.LoadScene(7);
		}
	}

	//Will return true if inclicted damage killed character
	public float decreaseStat(float damage){
		float adjustedDamage = adjustDamage (damage);
		curHealth -= adjustedDamage;
		return curHealth;
	}

	private float adjustDamage(float damage){
		return damage - characterDefense.getStat();
	}

	public bool isCharacterDead(){
		if (curHealth < 0) {
			return true;
		}
		return false;
	}
	public float increaseStat(float hp){
		curHealth += hp;
		return curHealth;
	}

	public float getStat(){
		return this.curHealth;
	}
}
