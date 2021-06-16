using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Mesa : Interactable
{
    public static event Action onUse = delegate { };
    public GameObject cutscene;
    public GameObject chefe, sobretudo, funcionario;
    public override void Action()
    {
        sobretudo.SetActive(true);
        chefe.SetActive(false);
        var f = FindObjectOfType<Funcionario>();
        if(f != null) Destroy(f.gameObject);
        onUse();
        Instantiate(cutscene);
        Desinteract();
    }
}
