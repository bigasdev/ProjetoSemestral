using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionObjective
{
    public string nome;
    public int quantity;
    public int maxQuantity;
    public MissionObjective(int _quantity){
        quantity = 0;
        maxQuantity = _quantity;
    }
    public virtual void AddObjetivo(){

    }
    public virtual void RemoveObjetivo(){
        
    }
    public bool Completo(){
        if(quantity >= maxQuantity){
            return true;
        }
        return false;
    }
    public virtual void OnTask(){
        quantity++;
        if(Completo()){
            RemoveObjetivo();
            Debug.Log("Task completa!");
            Engine.Instance.notifications.CreateNotification("Task completa : " + nome);
            Gamehud.hud.HideTab();
            for(int i = 0; i < Player.Instance.currentMissions.Count; i++){
                if(Player.Instance.currentMissions[i].objetivo == this){
                    Player.Instance.currentMissions.Remove(Player.Instance.currentMissions[i]);
                }
            }
        }
        Gamehud.hud.RefreshTab(Player.Instance.currentMissions);
    }
}
