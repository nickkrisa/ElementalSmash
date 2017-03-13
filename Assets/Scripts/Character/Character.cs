using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour{

	public bool userInputBool;
	public float horizSpeed;
	public float maxCharacterHorizVelocity;

	public int numOfJumps;
	public float vertJumpSpeed;
	private int curJumpsLeft;
	private float prevVertInput;
	private bool hasPhysicsJump;

	private Rigidbody2D rb2d;
	private Animator animator;

	private BoxCollider2D boxCollider;

	private float horizInput = 0;
	private float vertInput = 0;

	private void Start () {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	private void Update () {
		handleUserInputLogic ();
	}

	void OnCollisionEnter2D(Collision2D other){
		managePlatformLogic (other.gameObject);
	}

	void OnCollisionExit2D(Collision2D other){

	}

	void OnTriggerEnter2D(Collider2D other){
		
	}

	void OnTriggerExit2D(Collider2D other){
		
	}

	void FixedUpdate(){
		float vertForce = getVertForce(rb2d);
		float horizForce = getHorizForce();

		rb2d.AddForce (new Vector2 (horizForce, vertForce));
		rb2d.velocity = new Vector2 (Mathf.Clamp (rb2d.velocity.x, -maxCharacterHorizVelocity, maxCharacterHorizVelocity), rb2d.velocity.y);
	}

	private void handleUserInputLogic(){
		if (userInputBool) {
			horizInput = Input.GetAxisRaw ("Horizontal");
			vertInput = Input.GetAxisRaw ("Vertical");
			updateJump (vertInput);
		}
	}

	private void managePlatformLogic(GameObject gameObject){
		if (gameObject.tag == "Platform") {
			curJumpsLeft = numOfJumps;
		}
	}
	private void updateJump (float curVertInput){
		if (prevVertInput == 0 && curVertInput > 0) {
			if (curJumpsLeft > 0) {
				hasPhysicsJump = true;
			}
			curJumpsLeft--;
		}
		prevVertInput = curVertInput;
	}

	private float getVertForce(Rigidbody2D rgbd){
		if (hasPhysicsJump) {
			hasPhysicsJump = false;
			rgbd.velocity = new Vector2 (rb2d.velocity.x, 0);
			return (vertJumpSpeed * vertInput);
		}
		return 0;
	}
	private float getHorizForce(){
		return horizSpeed * horizInput;
	}
}
