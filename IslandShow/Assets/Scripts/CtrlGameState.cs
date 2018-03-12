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
	// Use this for initialization
	void Start ()
	{
	    gameState = gameStates.ACTIVE;

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
}
