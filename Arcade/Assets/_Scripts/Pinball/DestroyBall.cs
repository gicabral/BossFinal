using UnityEngine;
using UnityEngine.UI;

public class DestroyBall : MonoBehaviour
{
    public GameObject newBall;
    public Transform ball;
    public GameObject golight;
    //
    private Launcher launcherScript;
    private SpriteRenderer golightRenderer;
    private AnimateController golightAniController;
    private SoundController sound;
    private ScoreBoard score;

    private int maxBalls = 3;
    private int numBalls = 0;

    public GameObject playAgain;
    public GameObject scoreUI;
    private GameObject hudCanvas;
    public GameObject pausePanel;

    public enum GameState{
        Playing,
        GameOver,
        Paused,
    }

    public GameState gameState = GameState.Playing;

    void Start()
    {
        Time.timeScale = 1;
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        golightRenderer = golight.GetComponent<Renderer>() as SpriteRenderer;
        golightAniController = golight.GetComponent<AnimateController>();
        // check launcher object exists
        GameObject launcherObj = GameObject.Find("Plunger-springjoint");
        if (launcherObj != null)
        {
            launcherScript = launcherObj.GetComponent<Launcher>();
        }
        GameObject obj = GameObject.Find("scoreText");
        if (obj != null)
        {
            score = obj.GetComponent<ScoreBoard>();
        }
    }

    void Update(){
        if(numBalls == maxBalls){
            GameOver();
        }
        CheckInput();
    }

    void CheckInput(){
        if(gameState == GameState.Playing || gameState == GameState.GameOver){
            if(Input.GetKeyUp(KeyCode.Escape)){
                PauseResumeGame();
            }
        }

        if(gameState == GameState.GameOver){
            if(Input.GetKeyUp(KeyCode.Space)){
                StartGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            // on light
            golightRenderer.sprite = golightAniController.spriteSet[0];
            sound.die.Play();
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.name == "ball" && launcherScript != null && numBalls != maxBalls)
        {
            // off light & Destroy ball
            golightRenderer.sprite = golightAniController.spriteSet[1];
            Destroy(obj.gameObject);
            // new 
            GameObject newObj = Instantiate(newBall) as GameObject;
            newObj.name = "ball";
            newObj.transform.position = new Vector3(2.85f, -1f, 0f);
            // reset launcher
            launcherScript.isActive = true;
            numBalls+=1;
        }
    }

    void StartGame(){
        score.gamescore = 0;
        numBalls = 0;
        playAgain.SetActive(false);
        scoreUI.SetActive(false);
        gameState = GameState.Playing;
        launcherScript.isActive = true;
    }

    void GameOver(){
        Debug.Log("gameover");
        gameState = GameState.GameOver;
        launcherScript.isActive = false;
        playAgain.GetComponent<Text>().text = "PRESS SPACE TO PLAY AGAIN";
        scoreUI.GetComponent<Text>().text = "SCORE: " + score.gamescore;
        scoreUI.SetActive(true);
        playAgain.SetActive(true);
    }

    public void PauseResumeGame(){
        if(gameState == GameState.Paused){
            Time.timeScale = 1;
            gameState = GameState.Playing;
            playAgain.SetActive(false);
            scoreUI.SetActive(false);
            pausePanel.SetActive(false);
        }else{
            Time.timeScale = 0;
            gameState = GameState.Paused;
            pausePanel.SetActive(true);
        }
    }
}
