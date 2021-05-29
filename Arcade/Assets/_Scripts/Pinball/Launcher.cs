using UnityEngine;

public class Launcher : MonoBehaviour
{
    // EfxZoom
    public GameObject efxZoomObj;
    private SpriteRenderer efxZoomRenderer;
    private AnimateController efxZoomAniController;
    // EfxZoom light
    public GameObject efxLightObj;
    private SpriteRenderer efxLightRenderer;
    private AnimateController efxLightAniController;
    // Sound
    private SoundController sounds;
    private AudioSource pullSound;
    private AudioSource shootSound;
    // Touch Listener
    public bool isTouched = false;
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;
    // Timers
    private float pressTime = 0f;
    private float startTime = 0f;
    private int powerIndex;

    private SpringJoint2D joint;
    private Rigidbody2D rigidB;
    private float force = 0f;          
    public float maxForce = 90f;

    private DestroyBall game;


    void Start()
    {
        // zoom animation object
        efxZoomAniController = efxZoomObj.GetComponent<AnimateController>();
        efxLightAniController = efxLightObj.GetComponent<AnimateController>();
        // zoom light object
        efxZoomRenderer = efxZoomObj.GetComponent<Renderer>() as SpriteRenderer;
        efxLightRenderer = efxLightObj.GetComponent<Renderer>() as SpriteRenderer;
        // sounds
        sounds = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        pullSound = sounds.pulldown;
        shootSound = sounds.zonar;
        joint = GetComponent<SpringJoint2D>();
        joint.distance = 1f; 
        rigidB = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown("space"))
            {
                isKeyPress = true;
            }

            if (Input.GetKeyUp("space"))
            {
                isKeyPress = false;
            }

            // on keyboard press or touch hotspot
            if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
            {
                if (startTime == 0f)
                {
                    startTime = Time.time;
                    pullSound.Play();
                }
            }

            // on keyboard release 
            if (isKeyPress == false && isTouched == false && startTime != 0f)
            {
                // #1
                force = powerIndex * maxForce;

                shootSound.Play();
                // reset values & animation
                pressTime = 0f;
                startTime = 0f;
                efxLightRenderer.sprite = efxLightAniController.spriteSet[1];
                while (powerIndex >= 0)
                {
                    efxZoomRenderer.sprite = efxZoomAniController.spriteSet[powerIndex];
                    powerIndex--;
                }
            }
        }

        // Start Press
        if (startTime != 0f)
        {
            pressTime = Time.time - startTime;
            // plays zoom animation on loop
            powerIndex = (int)Mathf.PingPong(pressTime * efxZoomAniController.fps, efxZoomAniController.spriteSet.Length);
            efxZoomRenderer.sprite = efxZoomAniController.spriteSet[powerIndex];
            // turns on/ off zoom light based on powerIndex
            if (powerIndex == efxZoomAniController.spriteSet.Length - 1)
            {
                efxLightRenderer.sprite = efxLightAniController.spriteSet[0];
            }
            else
            {
                efxLightRenderer.sprite = efxLightAniController.spriteSet[1];
            }
        }
    }

    private void FixedUpdate()
    {
        if (force != 0)
        {
            joint.distance = 1f;
            rigidB.AddForce(Vector3.up * force);
            force = 0;
        }

        if (pressTime != 0)
        {
            joint.distance = 0.8f;
            rigidB.AddForce(Vector3.down * 400);
        }
    }

}
