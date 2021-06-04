using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDFrogger : MonoBehaviour
{

    public void LoadLevel(){
		Time.timeScale = 1f;
        SceneManager.LoadScene(0);
	}
}
