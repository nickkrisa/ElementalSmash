using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public Button close;
    public Button about;
    public Button vsai; //play vs AI
    public Button mp; //local multiplayer
    public Button practice; //free mode, test a character
    public Button credits;
    public Button back; //redirects to the main menu scene
    public Button beginpractice; //takes you to selected stage as your character to view/try moves
    public Button beginvsai; //takes you to selected stage as your character against your desired ai to fight them
    public Button beginmp; //takes you to selected stage as your chosen characters to fight against one another


    // Use this for initialization
    void Start()
    {

        close = close.GetComponent<Button>();
        about = about.GetComponent<Button>();
        vsai = vsai.GetComponent<Button>();
        mp = mp.GetComponent<Button>();
        practice = practice.GetComponent<Button>();
        credits = credits.GetComponent<Button>();
        back = back.GetComponent<Button>();
        beginpractice = beginpractice.GetComponent<Button>();
        beginvsai = beginvsai.GetComponent<Button>();
        beginmp = beginmp.GetComponent<Button>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //All buttons go to the first (0) scene right now, can change them to fit the correct ones.


    public void About() 
    {
        SceneManager.LoadScene(1);
    }
    public void Close()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void VsAi()
    {
        SceneManager.LoadScene(4);
    }
    public void Mp()
    {
        SceneManager.LoadScene(5);
    }
    public void Practice()
    {
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    //I don't know if i used return at all...
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    public void BeginPractice()
    {
        SceneManager.LoadScene(6);//not sure what scene yet...use dropdown i think. default is battleground since no others
    }
    public void BeginVsAi()
    {
        SceneManager.LoadScene(8);//not sure what scene yet...use dropdown i think. default is battleground since no others
    }
    public void BeginMp()
    {
        SceneManager.LoadScene(6);//not sure what scene yet...use dropdown i think. default is battleground since no others
    }
}

