using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool moveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        if (moveRight)
        {
            pos.x += Vector3.right.x * moveSpeed * Time.deltaTime;
            if (pos.x >= 9)
            {
                pos.x = -9;
            }
            
        } else 
        {
            pos.x += Vector3.left.x * moveSpeed * Time.deltaTime;
            if (pos.x <= -9)
            {
                pos.x = 9;
            }
            
        }
        transform.localPosition = pos;
    }
}
