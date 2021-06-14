using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Notificacao : MonoBehaviour
{
    [SerializeField] private Text notificationName;
    [SerializeField] Image fundo;
    [SerializeField] AudioClip notificationSound;

    public void Initialize(string notification){
        if(notificationSound != null) SoundManager.Instance.PlaySfx(notificationSound);
        notificationName.text = notification;
        StartCoroutine(notificationAction());
    }
    IEnumerator notificationAction(){
        notificationName.DOFade(1, 1.5f);
        fundo.DOFade(1f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        notificationName.DOFade(0, 1.5f);
        fundo.DOFade(0, 1.5f);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
