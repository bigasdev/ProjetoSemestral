using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontreAChefeNoAlmoxerifado : MissionObjective
{
    public EncontreAChefeNoAlmoxerifado(int _quantity) : base(_quantity){
        nome = "Encontre a chefe no almoxarifado";
    }
    public override void AddObjetivo()
    {
        Chefe.onTalk += OnTask;
    }
    public override void RemoveObjetivo()
    {
        Chefe.onTalk -= OnTask;
    }
}
