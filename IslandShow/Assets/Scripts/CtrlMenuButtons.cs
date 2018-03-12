using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlMenuButtons : MonoBehaviour
{
    public  Main main;
    public Button startButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button exitButton;

    // Use this for initialization
    void Start ()
    {
        main = FindObjectOfType<Main>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickStart()
    {
        main.changeSceneTo(Main.Scenes.GAME);
    }

    public void clickExit()
    {
        Application.Quit();
    }
}
