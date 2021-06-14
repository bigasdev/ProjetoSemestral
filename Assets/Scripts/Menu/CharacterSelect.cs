using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterSelect : MonoBehaviour
{
    [SerializeField] Image cabelo, roupa, sapato;
    [SerializeField] Sprite[] cabelos, roupas, sapatos;
    [SerializeField] int cabeloIndex = 0, roupaIndex = 0, sapatoIndex = 0;
    public AudioClip menuClick;
    void Refresh(){
        cabelo.sprite = cabelos[cabeloIndex];
        roupa.sprite = roupas[roupaIndex];
        sapato.sprite = sapatos[sapatoIndex];
    }

    public void Direita(string value){
        SoundManager.Instance.PlaySfx(menuClick);
        if(value == "Cabelo" && cabeloIndex < cabelos.Length - 1) cabeloIndex++;
        else if (value == "Cabelo" && cabeloIndex == cabelos.Length - 1) cabeloIndex = 0;
        if(value == "Roupa" && roupaIndex <  roupas.Length - 1) roupaIndex++;
        else if(value == "Roupa" && roupaIndex ==  roupas.Length - 1) roupaIndex = 0;
        if(value == "Sapato" && sapatoIndex < sapatos.Length - 1) sapatoIndex++;
        else if(value == "Sapato" && sapatoIndex == sapatos.Length - 1) sapatoIndex = 0;
        Refresh();
    }

    public void Esquerda(string value){
        SoundManager.Instance.PlaySfx(menuClick);
        if(value == "Cabelo" && cabeloIndex > 0) cabeloIndex--;
        else if(value == "Cabelo" && cabeloIndex == 0) cabeloIndex = cabelos.Length - 1;
        if(value == "Roupa" && roupaIndex > 0) roupaIndex--;
        else if(value == "Roupa" && roupaIndex ==  0) roupaIndex = roupas.Length - 1;
        if(value == "Sapato" && sapatoIndex > 0) sapatoIndex--;
        else if(value == "Sapato" && sapatoIndex ==  0) sapatoIndex = sapatos.Length - 1;
        Refresh();
    }

    public void Random(){
        SoundManager.Instance.PlaySfx(menuClick);
        cabeloIndex = UnityEngine.Random.Range(0, cabelos.Length);
        roupaIndex = UnityEngine.Random.Range(0, roupas.Length);
        sapatoIndex = UnityEngine.Random.Range(0, sapatos.Length);
        Refresh();
    }
    public void Aceitar(){
        SoundManager.Instance.PlaySfx(menuClick);
        Conta.Instance.CallSaveData(cabeloIndex, roupaIndex, sapatoIndex);
        PersonagemManager.Instance.CriarPersonagem(cabeloIndex, roupaIndex, sapatoIndex);
        Conta.Instance.criouPersonagem = true;
        SceneManager.LoadScene(1);
    }
}
