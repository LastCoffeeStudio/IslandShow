using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlGameState : MonoBehaviour {

    public enum gameStates
    {
        ACTIVE,
        PAUSE,
        DEBUG,
        WIN,
        EXIT
    }

    public  gameStates gameState;
    public GameObject[] endCameras;
    public float timeEndCamera;

    private uint activeEndCamera;
    private float timerEndCamera;
    
	// Use this for initialization
	void Start ()
	{
	    gameState = gameStates.ACTIVE;
        if (endCameras.Length < 0)
        {
            timerEndCamera = 0f;
            activeEndCamera = (uint)Random.Range(0, endCameras.Length);
        }
    }

    public gameStates getGameState()
    {
        return gameState;
    }

    public void setGameState(gameStates newGameState)
    {
        switch (newGameState)
        {
            case gameStates.ACTIVE:
            break;
            case gameStates.PAUSE:
                break;
            case gameStates.DEBUG:
                break;
            case gameStates.WIN:
                print("YOU WIIIIINNN!!!!");
                break;
            case gameStates.EXIT:
                break;
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case gameStates.ACTIVE:
                break;
            case gameStates.PAUSE:
                break;
            case gameStates.DEBUG:
                break;
            case gameStates.WIN:
                timerEndCamera -= Time.deltaTime;
                if (timerEndCamera <= 0f)
                {
                    if (endCameras.Length > 0)
                    {
                        endCameras[activeEndCamera].SetActive(false);
                        activeEndCamera = (uint)Random.Range(0, endCameras.Length);
                        endCameras[activeEndCamera].SetActive(true);
                    }

                    timerEndCamera = timeEndCamera;
                }
                break;
            case gameStates.EXIT:
                break;
        }
    }
}
