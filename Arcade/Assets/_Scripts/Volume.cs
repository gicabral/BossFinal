using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioSource[] music;
    public float vol;
    private static readonly string SoundEffectPref = "SoundEffectsPref";

    void Start()
    {
        vol = 0.05f;
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            vol+=0.05f;
            PlayerPrefs.SetFloat(SoundEffectPref, vol);
        } 
         
        if (Input.GetKeyUp(KeyCode.Alpha9)) {
            vol-=0.05f;
            PlayerPrefs.SetFloat(SoundEffectPref, vol);
        }
        SetLevel();
        
    }
    void SetLevel ()
    {
        vol = PlayerPrefs.GetFloat(SoundEffectPref);
        for(int i = 0; i < music.Length; i++){
            
            music[i].volume = vol;
        }
    }
}
