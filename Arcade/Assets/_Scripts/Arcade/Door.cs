using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Collide com player");
            myDoor.Play("Door", 0, 0.0f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("No longer in contact with " + other.transform.name);
        myDoor.Play("DoorC", 0, 0.0f);
    }


}
