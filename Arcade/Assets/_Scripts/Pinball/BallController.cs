using UnityEngine;

public class BallController : MonoBehaviour
{
    private AudioSource sound;
    private bool soundFlag = false;

    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D evt)
    {
        if (sound != null && soundFlag == false)
        {
            soundFlag = true;
            sound.Play();
        }
    }

    void OnCollisionExit2D(Collision2D evt)
    {
        soundFlag = false;
    }
}
