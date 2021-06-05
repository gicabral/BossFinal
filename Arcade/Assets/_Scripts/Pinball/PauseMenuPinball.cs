using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuPinball : MonoBehaviour
{

    private DestroyBall game;

    void Start(){
        game = GameObject.Find("FloorCollider").GetComponent<DestroyBall>();
    }

    //Reloads the Level
	public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void PlayControl(){
		Debug.Log("oi");
		game.PauseResumeGame();	
		
	}

	//loads inputted level
	public void LoadLevel(){
        SceneManager.LoadScene(0);
	}
}
