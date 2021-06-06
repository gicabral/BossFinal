using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
        // gameOverPanel UI for game text
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static GameObject gameOverPanelStatic;
    public static float gameOverTime = 0;
    public static bool isPaused = false;

    public enum GameState{
        Playing,
        GameOver,
        Paused,
    }
    public GameState gameState = GameState.Playing;

    void Start(){
        Time.timeScale = 1;
    }

    void Awake() {
        if (gameOverPanelStatic == null) {
            gameOverPanelStatic = gameOverPanel;
        }
    }
	
    // restart the game 
    public void restart() {
        Debug.Log("RESTART GAME!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // terminate the game
    public static void gameOver() {
        gameOverPanelStatic.SetActive(true);
        gameOverTime = Time.time;
    }

    public void togglePause() {
        if(gameState == GameState.Paused){
            Time.timeScale = 1;
            gameState = GameState.Playing;
            pausePanel.SetActive(false);
        }else{
            Time.timeScale = 0;
            gameState = GameState.Paused;
            pausePanel.SetActive(true);
        }    
        // Time.timeScale = Time.timeScale > 0 ? 0f : 1f;
        // isPaused = !isPaused;
        // pausePanel.SetActive(!pausePanel.activeSelf);
    }

    //Reloads the Level
	public void Reload(){
        Debug.Log(Time.timeScale);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
	}

	//controls the pausing of the scene
	public void PlayControl(){
		Debug.Log("oi");
		togglePause();	
		
	}

	//loads inputted level
	public void LoadLevel(){
        SceneManager.LoadScene(0);
	}

	// Update is called once per frame
	void Update () {
        if(gameState == GameState.Playing && !gameOverPanel.activeSelf){
            if (Input.GetKeyDown(KeyCode.Escape)) {
                togglePause();            
                
            }
        }
        if (gameOverPanel.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            //gameOverPanel.SetActive(false);
            restart();  
        } 
	}
}
