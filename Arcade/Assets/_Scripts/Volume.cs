using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioSource[] music;
    public float vol;
    public float vol_efx;

    void Start()
    {
        vol = 0.05f;
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.RightBracket)) {
            vol+=0.05f;
        } 
         
        if (Input.GetKeyUp(KeyCode.LeftBracket)) {
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
