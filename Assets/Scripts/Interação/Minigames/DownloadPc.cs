using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DownloadPc : MinigameObject
{
    public static event Action onComplete = delegate{};
    [SerializeField] AudioClip downloadSom;
    [SerializeField] Button download;
    [SerializeField] bool completo;
    [SerializeField] Animator animator;
    Coroutine sequence;
    public override void Initialize()
    {
        download.onClick.AddListener(Action);
    }
    void Action(){
        if(downloadSom != null) SoundManager.Instance.PlaySfx(downloadSom);
        if(sequence == null)sequence = StartCoroutine(Download());
    }
    IEnumerator Download(){
        animator.SetTrigger("Download");
        yield return new WaitForSeconds(9.5f);
        onComplete();
        completo = true;
        Close();
        Complete();
    }
}
