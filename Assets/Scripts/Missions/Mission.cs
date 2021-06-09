using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
   public string nome;
   public string description;
   public MissionObjective objetivo;
   public Mission(string _nome, string _description, MissionObjective _objetivo){
       nome = _nome;
       description = _description;
       objetivo = _objetivo;
   }
}
