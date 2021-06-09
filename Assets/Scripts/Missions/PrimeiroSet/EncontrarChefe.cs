using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarChefe : MissionObjective
{
    public EncontrarChefe(int _quantity) : base(_quantity){
        nome = "Encontre a chefe na praça de alimentação";
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
