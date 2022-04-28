using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]    //volume range from 0 to 1
    public float volume;
    [Range(.1f,3f)]    //pitch from .1 to 3
    public float pitch;

    
    [HideInInspector] 
    public AudioSource source; 

}
