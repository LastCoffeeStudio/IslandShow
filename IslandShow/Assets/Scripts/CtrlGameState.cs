using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.UIElements;

public class CtrlGameState : MonoBehaviour
{

    public GameObject score;
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
                score.SetActive(true);
                break;
            case gameStates.DEATH:
                print("YOU DEATH!!!!");
                score.SetActive(true);
                break;
            case gameStates.EXIT:
                break;
        }
    }
}
