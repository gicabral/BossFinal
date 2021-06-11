using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource[] music;
    public float vol;
    private static readonly string BackgroundPref = "BackgroundPref2";


    void Start()
    {
        vol = 0.2f;
        PlayerPrefs.SetFloat(BackgroundPref, vol);
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
        for(int i = 0; i < music.Length; i++){
            
            if (!music[i].isPlaying)
            {
                music[i].Play();
            }
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
