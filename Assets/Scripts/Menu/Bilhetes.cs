using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bilhetes : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] string texto;
    [SerializeField] Button closeButton;
    public bool openStart = false;

    private void Start() {
        if(openStart) Initialzie(texto);
    }
    public void Initialzie(string _text){
        text.text = _text;
        closeButton.onClick.AddListener(Close);
    }
    void Close(){
        Destroy(this.gameObject);
    }
}
