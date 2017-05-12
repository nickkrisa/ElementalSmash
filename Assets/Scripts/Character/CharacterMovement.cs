using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	public bool userInputBool;
	public float horizSpeed;
	public float maxCharacterHorizVelocity;

	public int thisPlayerIndex;
	private int player1Index;
	private int player2Index;
	private string horizontal;
	private string vertical; 

	public int numOfJumps;
	public float vertJumpSpeed;
	private int curJumpsLeft;
	private float prevVertInput;
	private bool hasPhysicsJump;

	private float horizInput = 0;
	private float lookDirection = -1;
	private float vertInput = 0;

	private Animator playerAnimator;
	private Rigidbody2D rb2d;
	private CharacterAttack attackController;

	private void Start () {
		attackController = GetComponent<CharacterAttack> ();
		player1Index = PlayerPrefs.GetInt ("FighterType1");
		player2Index = PlayerPrefs.GetInt ("FighterType2");

		if (thisPlayerIndex == player1Index) {
			horizontal = "Horizontal";
			vertical = "Vertical";
			attackController.attackKey = "q";
		} else if (thisPlayerIndex == player2Index) {
			horizontal = "Horizontal2";
			vertical = "Vertical2";
			attackController.attackKey = "/";
		} else {
			Destroy (this.gameObject);
		}

		rb2d = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
	}

	private void Update () {
		handleUserInputLogic ();
		playerAnimator.SetFloat ("Walking", rb2d.velocity.magnitude);
	}

	void OnCollisionEnter2D(Collision2D other){
		managePlatformLogic (other.gameObject);
	}

	void FixedUpdate(){
		float vertForce = getVertForce(rb2d);
		float horizForce = getHorizForce();

		rb2d.AddForce (new Vector2 (horizForce, vertForce));
		rb2d.velocity = new Vector2 (Mathf.Clamp (rb2d.velocity.x, -maxCharacterHorizVelocity, maxCharacterHorizVelocity), rb2d.velocity.y);
	}

	private void handleUserInputLogic(){
		if (userInputBool) {
			horizInput = Input.GetAxisRaw (horizontal);
			updateCharacterDirection (horizInput);
			vertInput = Input.GetAxisRaw (vertical);
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

	private void updateCharacterDirection(float horizInput){
		if (horizInput != 0) {
			if (horizInput != lookDirection) {
				lookDirection = horizInput;
				float degrees = 0;
				if (lookDirection == 1) {
					degrees = 180;
				}
				transform.rotation = Quaternion.Euler (0,degrees,0);
			}
		}
//		
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
