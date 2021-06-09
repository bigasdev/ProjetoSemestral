using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Escolha : MonoBehaviour
{
    [SerializeField] Text primeiraEscolha, segundaEscolha;
    [SerializeField] Button primeiro, segundo;
    [SerializeField] GameObject dialogo;
    [SerializeField] DialogoObject firstDialogo, segundoDialogo;

    public void Initialize(string escolha1, string escolha2, DialogoObject dialogo1, DialogoObject dialogo2){
        primeiraEscolha.text = escolha1;
        segundaEscolha.text = escolha2;
        firstDialogo = dialogo1;
        segundoDialogo = dialogo2;
        primeiro.onClick.AddListener(PrimeiraEscolha);
        segundo.onClick.AddListener(SegundaEscolha);
    }
    void PrimeiraEscolha(){
        Destroy(this.gameObject);
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize(firstDialogo.nome, "", null, firstDialogo);
    }
    void SegundaEscolha(){
        Destroy(this.gameObject);
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize(segundoDialogo.nome, "", null, segundoDialogo);
    }
}
