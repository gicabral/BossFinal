using UnityEngine;
using System.Collections;

public class Floatpiece : MonoBehaviour
{
    // Sound & Animation
    public GameObject handcamObj;
    public GameObject golightObj;
    private SpriteRenderer handcamRenderer;
    private SpriteRenderer golightRenderer;
    private AnimateController handcamAniController;
    private AnimateController golightAniController;
    private SoundController sound;
    private BuoyancyEffector2D effect;
    public float floatingDuration = 0f; 
    private float actualDuration = 0f; 
    private float startTime = 0f;


    // Score
    private ScoreBoard scoreBoard;

    void Start()
    {
        // Get scoreboard and sound object
        GameObject obj = GameObject.Find("scoreText");
        scoreBoard = obj.GetComponent<ScoreBoard>();
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        // Animation objects
        handcamRenderer = handcamObj.GetComponent<Renderer>() as SpriteRenderer;
        golightRenderer = golightObj.GetComponent<Renderer>() as SpriteRenderer;
        handcamAniController = handcamObj.GetComponent<AnimateController>();
        golightAniController = golightObj.GetComponent<AnimateController>();
        effect = GetComponent<BuoyancyEffector2D>();

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            effect.density = 50;
            if (startTime == 0f)
            {
                startTime = Time.time;
                sound.bonus.Play();
                scoreBoard.gamescore += 10;
                golightRenderer.sprite = golightAniController.spriteSet[0];
                StartCoroutine(BeginFloat());
            }

        }
    }

    IEnumerator BeginFloat()
    {
        while (true) 
        {
            actualDuration = Time.time - startTime; 

            // play animation loop
            int index = (int)Mathf.PingPong(handcamAniController.fps * 
                        Time.time, handcamAniController.spriteSet.Length);
            handcamRenderer.sprite = handcamAniController.spriteSet[index];
            yield return new WaitForSeconds(0.1f);
            
            // when time is up            
            if (actualDuration >= floatingDuration)  
            {
                // stop float and reset timer
                effect.density = 0;    
                actualDuration = 0f;
                startTime = 0f;
    
                // stop sound & animation 
                sound.bonus.Stop();
                golightRenderer.sprite = golightAniController.spriteSet[1];
                handcamRenderer.sprite = handcamAniController.spriteSet 
                            [handcamAniController.spriteSet.Length - 1];
                break;
            }
        } 
    }

}
