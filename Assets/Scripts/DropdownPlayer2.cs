using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DropdownPlayer2 : MonoBehaviour
{
    List<string> fighters = new List<string>() { "Please Select Player2 Fighter", "P2 Fire", "P2 Air", "P2 Earth", "P2 Water" };
    public Dropdown dropdown;
    public Text selectedFighter;


    public void Dropdown_IndexChanged(int index)
    {
        selectedFighter.text = fighters[index];
        if (index == 0)
        {
            selectedFighter.color = Color.red;
        }
        else
        {
            selectedFighter.color = Color.white;
        }
		PlayerPrefs.SetInt ("FighterType2", index - 1);
    }


    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {

        dropdown.AddOptions(fighters);
    }



}