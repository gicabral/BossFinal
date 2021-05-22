using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject InstructionsGames;

    private bool checkPong = false;
    private bool checkPacman = false;
    private bool checkFrogger = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pacman")
        {
            InstructionsGames.GetComponent<Text>().text = "PRESS SPACE TO PLAY PACMAN";
            InstructionsGames.SetActive(true);
            Debug.Log("Press space to play Pacman");
            checkPacman = true;
        }
        else if (collision.gameObject.tag == "Frogger")
        {
            InstructionsGames.GetComponent<Text>().text = "PRESS SPACE TO PLAY FROGGER";
            InstructionsGames.SetActive(true);
            Debug.Log("Press space to play Frogger");
            checkFrogger = true;
        }
        else if (collision.gameObject.tag == "Pong")
        {
            InstructionsGames.GetComponent<Text>().text = "PRESS SPACE TO PLAY PONG";
            InstructionsGames.SetActive(true);
            Debug.Log("Press space to play Pong");
            checkPong = true;
            
        }
        else if (collision.gameObject.tag == "Out")
        {
            SceneManager.LoadScene(4);
            
        }
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("No longer in contact with " + other.transform.name);
        InstructionsGames.SetActive(false);
        checkPong = false;
        checkPacman = false;
        checkFrogger = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && checkPong == true) 
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetButtonDown("Jump") && checkPacman == true) 
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetButtonDown("Jump") && checkFrogger == true) 
        {
            SceneManager.LoadScene(3);
        }
    }
}
