using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DropdownAI : MonoBehaviour
{
    List<string> fighters = new List<string>() { "Please Select AI Fighter", "AI Fire", "AI Air", "AI Earth", "AI Water" };
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