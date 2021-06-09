using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : Interactable
{
    [SerializeField] GameObject minigame;
    [SerializeField] AudioClip som;
    public bool completo;
    Coroutine action;
    public override void Action()
    {
        if(completo) return;
        Player.Instance.StopEverything();
        Engine.Instance.currentState = States.MINIGAME;
        if(action == null) StartCoroutine(StartAction());
        Desinteract();
    }
    public IEnumerator StartAction(){
        if(som != null) {
            SoundManager.Instance.PlaySfx(som);
            yield return new WaitForSeconds(som.length);
        }
        var minigameObject = Instantiate(minigame);
        minigameObject.GetComponent<MinigameObject>().minigame = this;
        action = null;
    }
}
