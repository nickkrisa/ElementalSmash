using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DropdownPlayer1 : MonoBehaviour
{
    List<string> fighters = new List<string>() { "Please Select Player1 Fighter", "P1 Fire", "P1 Air", "P1 Earth", "P1 Water" };
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
		PlayerPrefs.SetInt ("FighterType1", index - 1);
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