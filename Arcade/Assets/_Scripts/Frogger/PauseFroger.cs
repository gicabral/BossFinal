using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFroger : MonoBehaviour
{

    public GameObject frogger;

    //Reloads the Level
	public void Reload(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void PlayControl(){
		Time.timeScale = 1f;
		frogger.GetComponent<PlayerFrogger>().PauseResumeGame();
		
	}

	//loads inputted level
	public void LoadLevel(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(0);
	}
}

