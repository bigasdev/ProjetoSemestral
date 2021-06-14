using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversaComClientes : MissionObjective
{
    public ConversaComClientes(int _quantity) : base(_quantity){
        nome = "Converse com os clientes";
    }
    public override void AddObjetivo()
    {
        Npc.onTalk += OnTask;
    }
    public override void RemoveObjetivo()
    {
        Npc.onTalk -= OnTask;
    }
}
