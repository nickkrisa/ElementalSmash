using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text text;
    private int playerdead;

	// Use this for initialization
	void Start () {
        playerdead = PlayerPrefs.GetInt("DeadGuy");

        if (playerdead == PlayerPrefs.GetInt("FighterType1"))
        {
            text.text = "Player 2 Wins!";

        }
        else if (playerdead == PlayerPrefs.GetInt("FighterType2"))
        {
            text.text = "Player 1 Wins!";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
