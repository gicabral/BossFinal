using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Game : MonoBehaviour
{
    public Transform ball;

    private int computerScore;
    private int playerScore;
    public int winningScore = 5;


    private GameObject hudCanvas;
    private GameObject paddleComputer;
    private GameObject paddlePlayer;
    private HUD hud;

    public AudioClip playerWon;
    public AudioClip computerWon;
    public AudioClip lostBall;
    public Button home;
    
    public GameObject pausePanel;

    public enum GameState{
        Playing,
        GameOver,
        Paused,
        Launched
    }

    public GameState gameState = GameState.Launched;

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        paddleComputer = GameObject.Find("ComputerPaddle");
        paddlePlayer = GameObject.Find("PlayerPaddle");
        hudCanvas = GameObject.Find("HUDCanvas");
        hud = hudCanvas.GetComponent<HUD>();
        hud.playAgain.text = "PRESS SPACEBAR TO PLAY";
    }

    void Update()
    {
        CheckScore();
        CheckInput();
    }

    void CheckInput(){
        if(gameState == GameState.Playing){
            if(Input.GetKeyUp(KeyCode.Escape)){
                PauseResumeGame();
            }
        }
        if(gameState == GameState.Launched){
            home.gameObject.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Space)){
                StartGame();
            }
        }
        if(gameState == GameState.GameOver){
            home.gameObject.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Space)){
                StartGame2();
            }
        }
    }

    void CheckScore(){
        if(playerScore >= winningScore || computerScore >= winningScore){
            if(playerScore >= winningScore && computerScore < playerScore -1){
                //player wins
                PlayerWins();
            }
            else if(computerScore >= winningScore && playerScore < computerScore -1){
                //computer wins
                ComputerWins();
            }
        }
    }

    void SpawnBall()
    {
        Debug.Log("Entrou aqui");
        ball = GameObject.Instantiate(ball, new Vector3 (27.1f, 14.9f, -2), Quaternion.identity);
        ball.GetComponent<Ball>().enabled = true;
        ball.GetComponent<AudioSource>().enabled = true;
        ball.GetComponent<Volume>().enabled = true;
    }

    private void PlayerWins(){
        hud.winPlayer.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(playerWon, 0.7F);
        GameOver();
    }

    private void ComputerWins(){
        hud.winComputer.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(computerWon, 0.7F);
        GameOver();
    }

    public void ComputerPoint(){
        computerScore++;
        hud.computerScore.text = computerScore.ToString();
        GetComponent<AudioSource>().PlayOneShot(lostBall, 0.7F);
        NextRound();
    }

    public void PlayerPoint(){
        playerScore++;
        hud.playerScore.text = playerScore.ToString();
        GetComponent<AudioSource>().PlayOneShot(lostBall, 0.7F);
        NextRound();
    }

    private void StartGame(){
        playerScore = 0;
        computerScore = 0;
        
        hud.computerScore.text = "0";
        hud.playerScore.text = "0";
        hud.winComputer.enabled = false;
        hud.winPlayer.enabled = false;
        hud.playAgain.enabled = false;
        home.gameObject.SetActive(false);

        GetComponent<AudioSource>().Stop();

        gameState = GameState.Playing;
        paddleComputer.transform.localPosition = new Vector3(paddleComputer.transform.localPosition.x, 14.9f, paddleComputer.transform.localPosition.z);

        SpawnBall();
    }

    private void StartGame2(){
        playerScore = 0;
        computerScore = 0;
        
        hud.computerScore.text = "0";
        hud.playerScore.text = "0";
        hud.winComputer.enabled = false;
        hud.winPlayer.enabled = false;
        hud.playAgain.enabled = false;
        home.gameObject.SetActive(false);



        gameState = GameState.Playing;
        paddleComputer.transform.localPosition = new Vector3(paddleComputer.transform.localPosition.x, 14.9f, paddleComputer.transform.localPosition.z);
        paddlePlayer.transform.localPosition = new Vector3(paddlePlayer.transform.localPosition.x, 14.9f, paddlePlayer.transform.localPosition.z);

    }

    public void NextRound(){
        if(gameState == GameState.Playing){
            paddleComputer.transform.localPosition = new Vector3(paddleComputer.transform.localPosition.x, 14.9f, paddleComputer.transform.localPosition.z);
            GameObject.Destroy(ball.gameObject);
            SpawnBall();
        }
    }

    private void GameOver(){
        gameState = GameState.GameOver;
        GameObject.Destroy(ball.gameObject);   
        SpawnBall();    
        hud.playAgain.text = "PRESS SPACE TO PLAY AGAIN";
        hud.playAgain.enabled = true;
    }

    public void PauseResumeGame(){
        if(gameState == GameState.Paused){
            gameState = GameState.Playing;
            hud.playAgain.enabled = false;
            pausePanel.SetActive(false);
        }else{
            gameState = GameState.Paused;
            pausePanel.SetActive(true);
            // hud.playAgain.text = "GAME IS PAUSED PRESS SPACE TO RESUME";
            // hud.playAgain.enabled = true;
        }
    }
}
