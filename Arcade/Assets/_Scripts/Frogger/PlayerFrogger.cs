using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFrogger : MonoBehaviour
{
    public Image life1, life2, life3, life4, timeBand;
    public Sprite playerUp, playerDown, playerLeft, playerRight;
    private Vector3 originalPosition;
    public float gameTime = 30f, gameTimer = 0f, gameTimeWarning = 5f;
    private Vector3 startingTimeBandScale;
    public int health = 4;
    public Text scoreText;

    private int homeBays = 0;

    public Button home;
    public Text playAgain;
    public Text won;
    public Text lost;
    
    public GameObject pausePanel;

    public enum GameState{
        Playing,
        GameOver,
        Paused,
        Launched
    }

    public GameState gameState = GameState.Launched;



    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
        startingTimeBandScale = timeBand.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        CheckCollisions();
        CheckGameTimer();
        CheckInput();

    }

    void CheckInput(){
        if(gameState == GameState.Playing){
            if(Input.GetKeyUp(KeyCode.Escape)){
                PauseResumeGame();
            }
        }
        if(gameState == GameState.Launched){
            scoreText.enabled = false;
            won.enabled = false;
            lost.enabled = false;
            home.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if(Input.GetKeyUp(KeyCode.Space)){
                StartGame();
            }
        }

        if(gameState == GameState.GameOver){
            scoreText.enabled = false;
            home.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if(Input.GetKeyUp(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }

    private void StartGame(){
        scoreText.text = 0.ToString();
        Time.timeScale = 1f;
        home.gameObject.SetActive(false);
        playAgain.enabled = false;
        scoreText.enabled = true;
        gameState = GameState.Playing;
    }

    private void UpdatePosition()
    {
        Vector3 pos = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector3.up;
            UpdatePlayerScore(10);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
            if (pos.y > -6)
            {
                pos += Vector3.down;
                UpdatePlayerScore(10);
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            if (pos.x > -8)
            {   
                pos += Vector3.left;
                UpdatePlayerScore(10);
            }
            
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
            if (pos.x < 8)
            {
                pos += Vector3.right;
                UpdatePlayerScore(10);
            }
            
        }
        transform.localPosition = pos;
    }

    private void CheckCollisions()
    {
        bool isSafe = true;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Collidable");

        foreach (GameObject go in gameObjects)
        {
            CollidableObject collidableObject = go.GetComponent<CollidableObject>();

            if (collidableObject.isColliding(this.gameObject))
            {
                if (collidableObject.isSafe)
                {
                    isSafe = true;
                    if (collidableObject.isLog)
                    {
                        Vector3 pos = transform.localPosition;
                        if (collidableObject.GetComponent<Log>().moveRight)
                        {
                            pos.x += collidableObject.GetComponent<Log>().moveSpeed * Time.deltaTime;
                            if (transform.localPosition.x >= 9.5f)
                            {
                                pos.x = transform.localPosition.x - 18f;
                            }
                        } else
                        {
                            pos.x -= collidableObject.GetComponent<Log>().moveSpeed * Time.deltaTime;
                            if (transform.localPosition.x <= -9.5f)
                            {
                                pos.x = transform.localPosition.x + 18f;
                            }
                        } 
                        transform.localPosition = pos;
                    } else if (collidableObject.isTurtle)
                    {
                        Vector3 pos = transform.localPosition;
                        if (collidableObject.GetComponent<Turtle>().moveRight)
                        {
                            pos.x += collidableObject.GetComponent<Turtle>().moveSpeed * Time.deltaTime;
                            if (transform.localPosition.x >= 9.5f)
                            {
                                pos.x = transform.localPosition.x - 18f;
                            }
                        } else
                        {
                            pos.x -= collidableObject.GetComponent<Turtle>().moveSpeed * Time.deltaTime;
                            if (transform.localPosition.x <= -9.5f)
                            {
                                pos.x = transform.localPosition.x + 18f;
                            }
                        }
                        transform.localPosition = pos;
                    } else if (collidableObject.isHomeBay)
                    {
                        if (!collidableObject.isOccupied)
                        {
                            GameObject trophy = (GameObject)Instantiate(Resources.Load("Prefabs/trophy", typeof(GameObject)), collidableObject.transform.localPosition, Quaternion.identity);
                            collidableObject.isOccupied = true;
                            UpdatePlayerScore(50);
                            int timeRemaining = (int)(gameTime - gameTimer);
                            UpdatePlayerScore(timeRemaining);
                            ResetTimer();
                            homeBays += 1;
                        }
                        if (homeBays >= 5)
                        {
                            WonGame();
                        }
                        ResetPosition();
                    }
                break;
                } else 
                {
                    isSafe = false;
                }
            }
        }
        if (!isSafe)
        {

            if (health == 0)
            {
                GameOver();
            } else
            {      
                PlayerDied();
            }
        }
    }

    void GameOver()
    {
        health = 4;
        homeBays = 0;
        ResetPosition();
        lost.enabled = true;
        gameState = GameState.GameOver;
        scoreText.enabled = false;
        playAgain.enabled = true;
    }

    
    void WonGame()
    {
        health = 4;
        homeBays = 0;
        ResetPosition();
        won.enabled = true;
        gameState = GameState.GameOver;
        scoreText.enabled = false;
        playAgain.enabled = true;
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

    void PlayerDied()
    {
        
        DecreaseHealth();
        ResetPosition();
        ResetTimer();
    }

    void ResetPosition()
    {
        UpdatePlayerLivesHUD(health);
        transform.localPosition = originalPosition;
        GetComponent<SpriteRenderer>().sprite = playerUp;
    }

    public void UpdatePlayerLivesHUD(int playerHealth)
    {
        switch (playerHealth)
        {
            case 4:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
                life4.enabled = true;
                break;
            case 3:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
                life4.enabled = false;
                break;
            case 2:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = false;
                life4.enabled = false;
                break;
            case 1:
                life1.enabled = true;
                life2.enabled = false;
                life3.enabled = false;
                life4.enabled = false;
                break;
            case 0:
                life1.enabled = false;
                life2.enabled = false;
                life3.enabled = false;
                life4.enabled = false;
                break;
        }
    }

    public void UpdatePlayerScore (int score)
    {
        int currentScore = int.Parse(scoreText.text);
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    private void ResetTimer()
    {
        gameTimer = 0f;
    }

    private void DecreaseHealth()
    {
        health -= 1;
    }

    private void CheckGameTimer()
    {
        gameTimer += Time.deltaTime;
        Vector3 scale = new Vector3(startingTimeBandScale.x - gameTimer, startingTimeBandScale.y, startingTimeBandScale.z);
        timeBand.GetComponent<RectTransform>().localScale = scale;
        if (gameTimer  >= startingTimeBandScale.x - gameTimeWarning)
        {
            timeBand.GetComponent<Image>().color = Color.red;

        } else{
            timeBand.GetComponent<Image>().color = Color.black;
        }

        if (gameTimer >= gameTime)
        {
            if (health == 0)
            {
                GameOver();
            } else
            {      
                PlayerDied();
            }
            ResetTimer();

        }
        
    }
}
