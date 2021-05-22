using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float topBounds = 30.0f;
    public float bottomBounds = -3.7f;
    public Vector2 startingPosition = new Vector2(0.8f,14.9f);
    private Game game;

    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        transform.localPosition = (Vector3)startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(game.gameState == Game.GameState.Playing){
            CheckUserInput();
        }
    }

    void CheckUserInput(){
        if(Input.GetKey (KeyCode.UpArrow)){
            if (transform.localPosition.y >= topBounds){
                transform.localPosition = new Vector3(transform.localPosition.x, topBounds, transform.localPosition.z);
            }else{
                transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey (KeyCode.DownArrow)){
            if (transform.localPosition.y <= bottomBounds){
                transform.localPosition = new Vector3 (transform.localPosition.x, bottomBounds, transform.localPosition.z);
            }else{
                transform.localPosition += Vector3.down * moveSpeed * Time.deltaTime;
            }
        }
    }
}
