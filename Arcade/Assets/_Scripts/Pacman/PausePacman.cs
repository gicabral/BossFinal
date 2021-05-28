using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePacman : MonoBehaviour
{

    public GameObject game;

    //Reloads the Level
	public void Reload(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void PlayControl(){
		Time.timeScale = 1f;
		game.GetComponent<GamePacman>().PauseResumeGame();
		
	}

	//loads inputted level
	public void LoadLevel(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(0);
	}
}
