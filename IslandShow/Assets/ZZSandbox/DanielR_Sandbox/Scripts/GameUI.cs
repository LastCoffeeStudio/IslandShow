using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	[SerializeField]
	Image pauseScreen;

	[SerializeField]
	Slider healthBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TogglePauseScreen()
	{
		if (GameManager.gamePaused == false) 
		{
			pauseScreen.enabled = false;
		} 
		else 
		{
			pauseScreen.enabled = true;
		}
	}

	public void ChangeHealthBar(int value)
	{
		healthBar.value = value;
	}
}
