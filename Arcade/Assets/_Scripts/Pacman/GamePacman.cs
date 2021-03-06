using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class GamePacman : MonoBehaviour
{
    private int playerScore;
    private int winningScore = 332;
    public Button home;
    public Text playerScoreTxt;
    public Text playAgain;
    public Text won;
    public Text lost;

    public AudioClip playerPoint;
    public AudioClip playerDied;
    
    public GameObject pausePanel;

    public enum GameState{
        Playing,
        GameOver,
        Paused,
        Launched
    }

    public GameState gameState = GameState.Launched;

    void Update()
    {
        CheckScore();
        CheckInput();
    }

    void CheckInput(){
        if(gameState == GameState.Playing || gameState == GameState.GameOver){
            if(Input.GetKeyUp(KeyCode.Escape)){
                PauseResumeGame();
            }
        }
        if(gameState == GameState.Launched){
            playerScoreTxt.enabled = false;
            won.enabled = false;
            lost.enabled = false;
            home.gameObject.SetActive(true);
            GetComponent<Volume>().enabled = true;
            Time.timeScale = 0f;
            if(Input.GetKeyUp(KeyCode.Space)){
                StartGame();
            }
        }

        if(gameState == GameState.GameOver){
            playerScoreTxt.enabled = false;
            home.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if(Input.GetKeyUp(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }

    void CheckScore(){
        if(playerScore >= winningScore){
            //player wins
            PlayerWins();
        }
    }

    private void PlayerWins(){
        won.enabled = true;
        GameOver();
    }

    public void ComputerWins(){
        lost.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(playerDied, 0.7F);
        GameOver();
    }

    public void PlayerPoint(){
        GetComponent<AudioSource>().PlayOneShot(playerPoint, 0.7F);
        playerScore++;
        Debug.Log(playerScore);
        playerScoreTxt.text = playerScore.ToString();
        // GetComponent<AudioSource>().PlayOneShot(lostBall, 0.7F);
    }

    private void StartGame(){
        playerScore = 0;
        Time.timeScale = 1f;
        home.gameObject.SetActive(false);
        playAgain.enabled = false;
        playerScoreTxt.enabled = true;
        // hud.playerScore.text = "0";
        // hud.winComputer.enabled = false;
        // hud.winPlayer.enabled = false;
        // hud.playAgain.enabled = false;


        gameState = GameState.Playing;
    }

    private void GameOver(){
        gameState = GameState.GameOver;
        playAgain.enabled = true;
        playerScoreTxt.enabled = false;
    }

    public void PauseResumeGame(){
        if(gameState == GameState.Paused){
            gameState = GameState.Playing;
            pausePanel.SetActive(false);
        }else{
            gameState = GameState.Paused;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }
}
