using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    Rect playerRect;
    Vector3 playerSize;
    Vector3 playerPosition;

    Rect collidableObjectRect;
    Vector3 collidableObjectSize;
    Vector3 collidableObjectPosition;

    public bool isSafe;
    public bool isLog;
    public bool isTurtle;
    public bool isHomeBay;
    public bool isOccupied = false;

    public bool isColliding(GameObject playerGO)
    {
        playerSize = playerGO.transform.GetComponent<SpriteRenderer>().size;
        playerPosition = playerGO.transform.localPosition;

        collidableObjectSize = GetComponent<SpriteRenderer>().size;
        collidableObjectPosition = transform.localPosition;

        playerRect = new Rect(playerPosition.x - playerSize.x /2, playerPosition.y - playerSize.y /2, playerSize.x, playerSize.y);

        collidableObjectRect = new Rect(collidableObjectPosition.x - collidableObjectSize.x /2, collidableObjectPosition.y - collidableObjectSize.y /2, collidableObjectSize.x, collidableObjectSize.y);

        if (collidableObjectRect.Overlaps(playerRect, true))
        {
            return true;
        } 
        return false;
    }
}
