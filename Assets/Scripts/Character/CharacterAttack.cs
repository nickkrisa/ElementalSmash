﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour, ICharacterStat {

	public string attackKey;

	public float initialAttack;

	private float attack;

	private bool attacking = false;
	private float attackTimer = 0;
	public float attackCoolDown = 0.3f;
	public float specialCoolDown = 0.5f;

	public Collider2D attackZone;

	private Animator playerAnimator;

	void Awake(){
		playerAnimator = GetComponent<Animator> ();
		attackZone.enabled = false;
	}
	void Start(){
		this.attack = initialAttack;
	}

	void Update(){
		if (Input.GetKeyDown (attackKey) && !attacking) {
			attacking = true;
			attackTimer = attackCoolDown;

			attackZone.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackZone.enabled = false;
			}

			playerAnimator.SetBool ("Attacking", attacking);
		}
			
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
