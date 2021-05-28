using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDPacman : MonoBehaviour
{
    public Text playerScore;
    public Text winPlayer;
    public Text winComputer;
    public Text playAgain;

    public void LoadLevel(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(0);
	}
}
