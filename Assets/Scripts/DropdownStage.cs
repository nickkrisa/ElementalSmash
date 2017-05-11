using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DropdownStage : MonoBehaviour
{
    List<string> stages = new List<string>() { "Please Select a Stage", "Battleground" };
    public Dropdown dropdown;
    public Text selectedStage;


    public void Dropdown_IndexChanged(int index)
    {
        selectedStage.text = stages[index];
        if (index == 0)
        {
            selectedStage.color = Color.red;
        }
        else
        {
            selectedStage.color = Color.white;
        }
    }


    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {

        dropdown.AddOptions(stages);
    }



}