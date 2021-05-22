using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Collide com player");
            myDoor.Play("DoorOpens", 0, 0.0f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("No longer in contact with " + other.transform.name);
        myDoor.Play("DoorClose", 0, 0.0f);
    }


}
