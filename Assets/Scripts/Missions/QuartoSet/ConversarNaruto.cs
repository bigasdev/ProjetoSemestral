using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversarNaruto : MissionObjective
{
    public ConversarNaruto(int _quantity) : base(_quantity){
        nome = "Converse com o npc vestido de naruto";
    }
    public override void AddObjetivo()
    {
        Naruto.onTalk += OnTask;
    }
    public override void RemoveObjetivo()
    {
        Naruto.onTalk -= OnTask;
    }
}
