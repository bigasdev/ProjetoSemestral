using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bilhete : Interactable
{
    public static event Action onPick = delegate { };
    public GameObject bilhete;
    public string text;
    public AudioClip pickSound;
    public override void Action()
    {
        onPick();
        Desinteract();
        if(bilhete != null){
            if(pickSound != null) SoundManager.Instance.PlaySfx(pickSound);
            var b = Instantiate(bilhete);
            b.GetComponent<Bilhetes>().Initialzie(text);
        }
        Destroy(this.gameObject);
    }
}
