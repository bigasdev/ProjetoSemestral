using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Notificacao : MonoBehaviour
{
    [SerializeField] private Text notificationName;
    [SerializeField] Image fundo;

    public void Initialize(string notification){
        notificationName.text = notification;
        StartCoroutine(notificationAction());
    }
    IEnumerator notificationAction(){
        notificationName.DOFade(1, .5f);
        fundo.DOFade(1f, .5f);
        yield return new WaitForSeconds(.5f);
        notificationName.DOFade(0, .5f);
        fundo.DOFade(0, .5f);
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
