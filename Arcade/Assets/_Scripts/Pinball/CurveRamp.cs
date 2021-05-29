using UnityEngine;

public class CurveRamp : MonoBehaviour
{
    private ScoreBoard scoreBoard;
    private AnimateController aniController;
    private SpriteRenderer thisRenderer;
    private int score;

    public GameObject curveLampLightObj;
    public bool isInRamp = false;

    void Start()
    {
        // animation object
        thisRenderer = curveLampLightObj.GetComponent<Renderer>() as SpriteRenderer;
        aniController = curveLampLightObj.GetComponent<AnimateController>();
        // get scoreboard object
        GameObject obj = GameObject.Find("scoreText");
        if (obj != null)
        {
            scoreBoard = obj.GetComponent<ScoreBoard>();
        }
    }

    void Update()
    {
        if (isInRamp && scoreBoard != null)
        {
            scoreBoard.gamescore = scoreBoard.gamescore + 1;
            thisRenderer.sprite = aniController.spriteSet[0];
        }
        else
        {
            thisRenderer.sprite = aniController.spriteSet[1];
        }
    }
}
