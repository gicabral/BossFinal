using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsAudio : MonoBehaviour
{
    public GameObject InstructionsStart;

    public float time = 3; //Seconds to read the text

    IEnumerator Start ()
    {
        yield return new WaitForSeconds(time);
        InstructionsStart.SetActive(false);
    }
}
