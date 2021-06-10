using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource[] music;
    public float vol;

    void Start()
    {
        vol = 0.1f;
    }
    
    void Update(){
        if (Input.GetKeyUp(KeyCode.Equals)) {
            vol+=0.05f;
        } 
         
        if (Input.GetKeyUp(KeyCode.Minus)) {
            vol-=0.05f;
        }
        SetLevel();
        
    }
    void SetLevel ()
    {
        for(int i = 0; i < music.Length; i++){
            
            music[i].volume = vol;
        }
    }
}
