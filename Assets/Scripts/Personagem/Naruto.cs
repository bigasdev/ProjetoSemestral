using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Naruto : Interactable
{
    public static event Action onTalk = delegate { };
    public DialogoObject dialogoObject;
    public GameObject chefe;
    public override void Action()
    {
        chefe.SetActive(true);
        onTalk();
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("Naruto", "", null, dialogoObject);
        Desinteract();
    }
}
