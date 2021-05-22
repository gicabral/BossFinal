﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float topBounds = 30.0f;
    public float bottomBounds = -3.7f;
    public Vector2 startingPosition = new Vector2(28.7f,14.9f);

    private GameObject ball;
    private Vector2 ballPos;

    private Game game;

    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        transform.localPosition = (Vector3)startingPosition;
    }

    void Update()
    {
        if(game.gameState == Game.GameState.Playing){
            Move();
        }
    }

    void Move(){
        if(!ball){
            ball = GameObject.FindGameObjectWithTag("ball");
        }
        if(ball.GetComponent<Ball>().ballDirection == Vector2.right){
            ballPos = ball.transform.localPosition;

            if(transform.localPosition.y > bottomBounds && ballPos.y < transform.localPosition.y){
                transform.localPosition += new Vector3(0, -moveSpeed*Time.deltaTime, 0);
            }

            if (transform.localPosition.y < topBounds && ballPos.y > transform.localPosition.y){
                transform.localPosition += new Vector3(0, moveSpeed*Time.deltaTime,0);
            }
        }
    }
}
