using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CtrlGameState : MonoBehaviour {

    public enum gameStates
    {
        ACTIVE,
        PAUSE,
        DEBUG,
        WIN,
        DEATH,
        EXIT
    }

    public gameStates gameState;
  

    
	// Use this for initialization
	void Start ()
	{
	    Lightmapping.Bake();
        gameState = gameStates.WIN;
      
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
                gameObject.GetComponent<CtrlCamerasWin>().enabled = true;
                //TODO: Got to Score sceen
                break;
            case gameStates.DEATH:
                print("YOU DEATH!!!!");
                //TODO: Got to Score sceen
                break;
            case gameStates.EXIT:
                break;
        }
    }
}
