using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Chefe : Interactable
{
    public static event Action onTalk = delegate { };
    public DialogoObject dialogoObject;
    public override void Action()
    {
        onTalk();
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("Chefe", "", null, dialogoObject);
        Desinteract();
    }
}
