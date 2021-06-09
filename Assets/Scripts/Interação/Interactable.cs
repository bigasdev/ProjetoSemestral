using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public GameObject interaction;
    public GameObject dialogo;
    public void Interact(){
        interaction.SetActive(true);
    }
    public void Desinteract(){
        interaction.SetActive(false);
    }
    public virtual void Action(){
        
    }
}
