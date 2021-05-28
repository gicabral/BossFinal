using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{

    public GameObject game;


    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pacman"){
            Destroy(gameObject);
            game.GetComponent<GamePacman>().PlayerPoint();
        }
            
    }
}
