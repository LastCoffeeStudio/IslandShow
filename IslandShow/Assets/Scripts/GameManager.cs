using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static bool debugMode = false;
	public static bool gamePaused = false;

	[SerializeField]
	GameUI gameUI;
    
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
        {
            debugMode = !debugMode;
        }

		if (Input.GetKeyDown(KeyCode.P))
		{
			PauseUnPause ();
		}
	}

	void PauseUnPause()
	{
		gamePaused = !gamePaused;
		if (gameUI) 
		{
			gameUI.TogglePauseScreen ();
		}

		if (gamePaused) 
		{
			Time.timeScale = 0;
		} 
		else 
		{
			Time.timeScale = 1;
		}
	}
}
