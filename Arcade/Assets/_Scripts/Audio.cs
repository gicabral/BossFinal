using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource[] music;
    public float vol;
    private static readonly string BackgroundPref = "BackgroundPref";


    void Start()
    {
        vol = 0.1f;
    }
    
    void Update(){
        if (Input.GetKeyUp(KeyCode.Equals)) {
            vol+=0.05f;
            PlayerPrefs.SetFloat(BackgroundPref, vol);
        } 
         
        if (Input.GetKeyUp(KeyCode.Minus)) {
            vol-=0.05f;
            PlayerPrefs.SetFloat(BackgroundPref, vol);
        }
        SetLevel();
        
    }
    void SetLevel ()
    {
        vol = PlayerPrefs.GetFloat(BackgroundPref);
        for(int i = 0; i < music.Length; i++){
            
            music[i].volume = vol;
        }
    }
}
