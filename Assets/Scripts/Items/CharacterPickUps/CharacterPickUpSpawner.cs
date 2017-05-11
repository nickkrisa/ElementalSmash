using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickUpSpawner : MonoBehaviour {

	public float launchSpeed;

	public float timeToWaitBetweenSpawns;
	private float currentEllapsedTime;
	public CharacterPickUp[] characterPickUpsToSpawn;
	// Use this for initialization
	void Start () {
		currentEllapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		updateEllapsedTime ();
		if (isItTimeToSpawnANewPickUp ()) {
			spawnNewPickUp ();
		}
	}

	private void updateEllapsedTime(){
		currentEllapsedTime += Time.deltaTime;
	}
	private bool isItTimeToSpawnANewPickUp(){
		return currentEllapsedTime > timeToWaitBetweenSpawns;
	}
	private void spawnNewPickUp(){
		int randomSpawnIndex = Random.Range (0, characterPickUpsToSpawn.Length);
		CharacterPickUp selectedCharacterPickUp = characterPickUpsToSpawn [randomSpawnIndex];
		CharacterPickUp spawnedCharacterPickUp = Instantiate(selectedCharacterPickUp, transform.position, transform.rotation) as CharacterPickUp;
		spawnedCharacterPickUp.transform.parent = transform;

		launchPickUpInRandomDirection (spawnedCharacterPickUp);
		currentEllapsedTime = 0;
	}

	private void launchPickUpInRandomDirection(CharacterPickUp characterPickupToLaunch){
		Rigidbody2D rgb2d = characterPickupToLaunch.GetComponent<Rigidbody2D> ();

		Vector2 launchDirection = new Vector2 (getXLaunchDirection (), getYLaunchDirection ());
		rgb2d.AddForce (launchDirection * launchSpeed);

	}
	private float getXLaunchDirection(){
		return Random.Range (-1f, 1f);
	}
	private float getYLaunchDirection(){
		return Random.Range (0f, 1f);
	}
}
