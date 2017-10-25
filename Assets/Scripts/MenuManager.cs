using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameStates {MainMenu, Game, Pause, GameOver, HighScoreEntry, HighScore};
public class MenuManager : MonoBehaviour { 
	private GameStates m_CurrentState = GameStates.MainMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void MainMenu(){
		DeactivateControls();
		Pause();
		ResetGame();
		//ShowMainMenu
	}
	private void MainGame(){
		ActivateControls();
		UnPause();
		//ShowHUDMenu
	}
	private void PauseMenu(){
		Pause();
		DeactivateControls();
		//ShowPauseMenu
	}
	private void GameOverMenu(){
		Pause();
		DeactivateControls();
		ResetGame();
		//ShowGameOverMenu
	}
	private void HighScoreEntryMenu(){
		//ShowHighScoreEntryMenu
	}
	private void HighScoreMenu(){
		//ShowHighScoreMenu
	}
	private void Pause(){
		Time.timeScale = 0;
	}
	private void DeactivateControls(){
		GameManager.Instance.m_Player.GetComponent<DuckController>().enabled = false;
		GameManager.Instance.m_Player.GetComponent<ScrollingController>().enabled = false;
		
	}
	private void ResetGame(){

	}
	private void ActivateControls(){

	}
	private void UnPause(){
		Time.timeScale = 1.0f;
	}
}
