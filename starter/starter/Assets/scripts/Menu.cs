﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Data data;

	// Use this for initialization
	void Start () {
		if(data.GameState== GameStates.MainMenu ||data.GameState== GameStates.Paused) {
			Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}
	void OnGUI() {
		switch (data.GameState)
		{
		case GameStates.MainMenu:
			MainMenu();
			break;
		case GameStates.Paused:
			PauseMenu();
			break;
		case GameStates.GameOver:
			GameOverMenu();
			break;
		}
		
	}
	void MainMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Start")) {
			StartGame();
		}
	}
	void GameOverMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "Congratulations");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Restart")) {
			ReStartGame();
		}
	}
	void WinMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "GAME OVER");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Retry")) {
			ReStartGame();
		}
	}
	void PauseMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "PAUSED");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Continue")) {
			UnPause();
		}
	}
	void Pause() {
		Time.timeScale = 0;
		data.GameState = GameStates.Paused;
	}
	void UnPause() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
	}
	void StartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		//TODO: Send message
	}
	void ReStartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		Application.LoadLevel(Application.loadedLevel);
		//TODO: Send message
	}
}