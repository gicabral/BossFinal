using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject playAgain;
    bool check = false;

    void Start()
    {
        StartCoroutine(CreditEnd());
        
    }

    IEnumerator CreditEnd(){
        yield return new WaitForSeconds(7);
        playAgain.SetActive(true);
        check = true;
    }

    public void FixedUpdate(){
        if (Input.GetButtonDown("Jump") && check == true) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
