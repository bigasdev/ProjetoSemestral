using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Funcionario : Interactable
{
    public static event Action onTalk = delegate { };
    public DialogoObject dialogoObject;
    public override void Action()
    {
        onTalk();
        var chefe = FindObjectOfType<Chefe>();
        if(chefe != null) Destroy(chefe.gameObject);
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("Funcionario", "", null, dialogoObject);
        Desinteract();
    }
}
