using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private Game game;

    void Start(){
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    //Reloads the Level
	public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void PlayControl(){
		game.PauseResumeGame();	
	}

	//loads inputted level
	public void LoadLevel(){
        SceneManager.LoadScene(0);
	}
}
