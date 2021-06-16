using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PainelDeLuz : MinigameObject
{
    public static event Action onComplete = delegate{};
    [SerializeField] AudioClip consertoSom;
    [SerializeField] Button fio;
    [SerializeField] bool completo;
    [SerializeField] Animator animator;
    public override void Initialize()
    {
        fio.onClick.AddListener(Conserto);
    }
    void Conserto(){
        if(consertoSom != null) SoundManager.Instance.PlayOst(consertoSom);
        completo = true;
        animator.SetBool("Concluida", true);
        Complete();
    }
    public override void Complete()
    {
        base.Complete();
        onComplete();
        Engine.Instance.SetDay();
    }
}
