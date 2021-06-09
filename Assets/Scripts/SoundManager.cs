using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }
    public AudioSource sfx, ost, ambient;
    public Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();

    private void Start() {
        sounds.Add("Sfx", sfx);
        sounds.Add("Ost", ost);
        sounds.Add("Ambient", ambient);
    }
    public void ChangeVolume(string source, float amount){
        sounds[source].volume = amount;
    }
    public void PlaySfx(AudioClip clip){
        sfx.PlayOneShot(clip);
    }
    public void PlayOst(AudioClip clip){
        ost.PlayOneShot(clip);
    }
    public void PlayAmbient(AudioClip clip){
        ambient.PlayOneShot(clip);
    }
    public void StopOst(){
        ost.Stop();
    }
    public void StopSfx(){
        sfx.Stop();
    }
}
