using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Script q vai ser responsavel pelos botoes
public class Botao : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] Vector3 firstShake, secondShake, finalShake;
    Coroutine shake;

    public void OnPointerEnter(PointerEventData eventData){
        if(shake == null){
            shake = StartCoroutine(shakeOnMouse());
        }
    }
    IEnumerator shakeOnMouse(){
        gameObject.transform.DOLocalRotate(firstShake, .15f, RotateMode.Fast);
        yield return new WaitForSeconds(.15f);
        gameObject.transform.DOLocalRotate(secondShake, .15f, RotateMode.Fast);
        yield return new WaitForSeconds(.15f);
        gameObject.transform.DOLocalRotate(finalShake, .15f, RotateMode.Fast);
        shake = null;
        yield return null;
    }
}
