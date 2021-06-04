using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public enum TurtleType
    {
        TurtleTypeFloating,
        TurtleTypeDiving
    }

    public TurtleType turtleType = TurtleType.TurtleTypeFloating;

    public Sprite turtleDiveSprite;
    public Sprite turtleFloatSprite;

    public float moveSpeed = 5f;
    public bool moveRight = true;
    private readonly float playAreaWidth = 19.0f;

    private bool shouldDive = false, shouldSurface = true, didDive = false, didSurface = false;

    private float surfaceTime = 5f, diveTime = 5f, surfaceTimer = 0f, diveTimer = 0f, transitionTime = 5f, transitionTimer = 0f;

    void Update()
    {
       UpdateTurtlePosition();
       UpdateDiveTurtleStatus();
    }

    void UpdateTurtlePosition()
    {
        Vector3 pos = transform.localPosition;

        if (moveRight)
        {
            pos.x += moveSpeed * Time.deltaTime;
            if (pos.x >= ((playAreaWidth/2)-1) + (playAreaWidth - 1) - GetComponent<SpriteRenderer>().size.x / 2)
            {
                pos.x = -playAreaWidth/2 - GetComponent<SpriteRenderer>().size.x/2;
            }
        } else
        {
            pos.x -= moveSpeed * Time.deltaTime;
            if (pos.x <= ((-playAreaWidth/2)+1) - (playAreaWidth - 1) + GetComponent<SpriteRenderer>().size.x / 2)
            {
                pos.x = playAreaWidth/2 + GetComponent<SpriteRenderer>().size.x/2;
            }
        }


        transform.localPosition = pos;
    }

    void UpdateDiveTurtleStatus()
    {
        if (turtleType == TurtleType.TurtleTypeDiving)
        {
            if (shouldSurface)
            {
                transitionTimer += Time.deltaTime;
                if (transitionTimer >= transitionTime)
                {
                    shouldSurface = false;
                    transitionTimer = 0f;
                    didSurface = true;
                    GetComponent<SpriteRenderer>().sprite = turtleFloatSprite;
                }
            }

            if (didSurface)
            {
                surfaceTimer += Time.deltaTime;
                if(surfaceTimer >= surfaceTime)
                {
                    didSurface = false;
                    surfaceTimer = 0f;
                    GetComponent<SpriteRenderer>().sprite = turtleDiveSprite;
                    shouldDive = true;
                }
            }

            if (shouldDive)
            {
                transitionTimer += Time.deltaTime;
                if (transitionTimer >= transitionTime)
                {
                    shouldDive = false;
                    transitionTimer = 0f;
                    didDive = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CollidableObject>().isSafe = false;
                }
            }
            if (didDive)
            {
                diveTimer += Time.deltaTime;
                if (diveTimer >= diveTime)
                {
                    shouldSurface = true;
                    diveTimer = 0f;
                    didDive = false;
                    GetComponent<SpriteRenderer>().enabled = true;
                    GetComponent<CollidableObject>().isSafe = true;
                    GetComponent<SpriteRenderer>().sprite = turtleDiveSprite;
                }
            }
        }
    }
}
