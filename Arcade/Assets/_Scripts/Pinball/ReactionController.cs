using UnityEngine;
using System.Collections;

public class ReactionController : MonoBehaviour
{
    private AnimateController animateController;
    private SpriteRenderer thisRenderer;
    private AudioSource sound;

    // Use this for initialization
    void Start()
    {
        animateController = GetComponent<AnimateController>();
        thisRenderer = GetComponent<Renderer>() as SpriteRenderer;
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (sound != null && obj.name == "ball")
        {
            sound.Play();
        }
        StartCoroutine(PlayAnimation());
    }

    void OnCollisionEnter2D(Collision2D evt)
    {
        if (sound != null)
        {
            sound.Play();
        }
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        for (int i = 0; i < animateController.spriteSet.Length - 1; i++)
        {
            thisRenderer.sprite = animateController.spriteSet[i];
            yield return new WaitForSeconds(animateController.fps / 10);
        }
    }
}
