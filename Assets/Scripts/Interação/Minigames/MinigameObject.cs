using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinigameObject : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] AudioClip closeSound;
    public Minigame minigame;
    private void Start() {
        closeButton.onClick.AddListener(Close);
        Initialize();
    }
    public void Close(){
        SoundManager.Instance.StopSfx();
        if(closeSound != null) SoundManager.Instance.PlaySfx(closeSound);
        Engine.Instance.currentState = States.GAME_UPDATE;
        Destroy(this.gameObject);
    }
    public virtual void Complete(){
        minigame.completo = true;
    }
    public virtual void Initialize(){

    }
}
