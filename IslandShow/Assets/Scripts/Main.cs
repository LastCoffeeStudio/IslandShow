using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Scenes sceneSelected;

    public enum Scenes
    {
        MENU,
        GAME
    }

	// Use this for initialization
	void Start ()
	{
	   // Object.DontDestroyOnLoad(this.gameObject);
        sceneSelected = Scenes.MENU;
	}
	
    public void changeSceneTo(Scenes newScene)
    {
        sceneSelected = newScene;
        SceneManager.LoadScene((int)newScene);
    }

}
