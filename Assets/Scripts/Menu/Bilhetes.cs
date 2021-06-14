using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bilhetes : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Button closeButton;

    public void Initialzie(string _text){
        text.text = _text;
        closeButton.onClick.AddListener(Close);
    }
    void Close(){
        Destroy(this.gameObject);
    }
}
