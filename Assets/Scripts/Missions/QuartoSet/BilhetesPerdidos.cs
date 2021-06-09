using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilhetesPerdidos : MissionObjective
{
    public BilhetesPerdidos(int _quantity) : base(_quantity){
        nome = "Encontre os bilhetes perdidos";
    }
}
