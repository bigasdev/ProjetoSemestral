using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Lampada : Interactable
{
    public static event Action onPick = delegate { };
    public GameObject cutscene;
    public GameObject bilhetes;
    public override void Action()
    {
        onPick();
        Desinteract();
        if(cutscene != null)Instantiate(cutscene);
        if(bilhetes != null) bilhetes.SetActive(true);
        Destroy(this.gameObject);
    }
}
