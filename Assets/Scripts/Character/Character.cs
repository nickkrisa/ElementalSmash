using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour{

	private CharacterMovement characterMovement;

	private Rigidbody2D rb2d;
	private Animator animator;

	private BoxCollider2D boxCollider;

	private float horizInput = 0;
	private float vertInput = 0;

	private void Start () {
		characterMovement = GetComponent<CharacterMovement> ();
		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D> ();
	}

	private void Update () {
		
	}

	void FixedUpdate(){

	}

	void OnCollisionEnter2D(Collision2D other){
		
	}

	void OnCollisionExit2D(Collision2D other){

	}

	void OnTriggerEnter2D(Collider2D other){
		
	}

	void OnTriggerExit2D(Collider2D other){
		
	}
}
