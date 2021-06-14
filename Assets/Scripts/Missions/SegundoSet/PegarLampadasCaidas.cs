using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarLampadasCaidas : MissionObjective
{
    public PegarLampadasCaidas(int _quantity) : base(_quantity){
        nome = "Recolha as lâmpadas caidas";
    }
    public override void AddObjetivo()
    {
        Lampada.onPick += OnTask;
    }
    public override void RemoveObjetivo()
    {
        Lampada.onPick -= OnTask;
    }
}
