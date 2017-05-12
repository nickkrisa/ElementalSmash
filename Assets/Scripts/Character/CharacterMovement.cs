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
	private int aiIndex;
	private string horizontal;
	private string vertical; 
	public bool isAIMove = false;

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
	private GameObject otherCharacter;
	private CameraControl cameraScript;

	private void Start () {
		attackController = GetComponent<CharacterAttack> ();
		player1Index = PlayerPrefs.GetInt ("FighterType1");
		player2Index = PlayerPrefs.GetInt ("FighterType2");
		aiIndex = PlayerPrefs.GetInt ("FighterTypeAI");
		cameraScript = Camera.main.GetComponent<CameraControl> ();

		if (thisPlayerIndex == player1Index) {
			horizontal = "Horizontal";
			vertical = "Vertical";
			attackController.attackKey = "q";
			cameraScript.target1 = this.gameObject;
		} else if (thisPlayerIndex == player2Index) {
			horizontal = "Horizontal2";
			vertical = "Vertical2";
			attackController.attackKey = ".";
			cameraScript.target2 = this.gameObject;
		} 
		else if (thisPlayerIndex == aiIndex) {
			isAIMove = true;
			GetOtherPlayer ();
			cameraScript.target2 = this.gameObject;
		} 
		else {
			Destroy (this.gameObject);
		}

		rb2d = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
	}

	private void Update () {
		if (isAIMove) {
			AIMovement ();
		} else {
			handleUserInputLogic ();
		}
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

	private void AIMovement() {
		Vector3 otherLocation = otherCharacter.transform.position;
		float horizForce;
	
		float horizDiff = otherLocation.x - transform.position.x;
		if (horizDiff > 0) {
			horizForce = horizSpeed;
		} else  {
			horizForce = horizSpeed * -1;
		}

		rb2d.AddForce (new Vector2 (horizForce, 0));
		rb2d.velocity = new Vector2 (Mathf.Clamp (rb2d.velocity.x, -2, 2), rb2d.velocity.y);
	}

	private void GetOtherPlayer() {
		if (player1Index == 0) {
			otherCharacter = GameObject.Find ("FlameCharacter");
		}
		else if (player1Index == 1) {
			otherCharacter = GameObject.Find ("AirCharacter");
		}
		else if (player1Index == 2) {
			otherCharacter = GameObject.Find ("EarthCharacter");
		}
		else {
			otherCharacter = GameObject.Find ("WaterCharacter");
		}
	}
}
