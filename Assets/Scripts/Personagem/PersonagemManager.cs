using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemManager : MonoBehaviour
{
    private static PersonagemManager instance;
    public static PersonagemManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<PersonagemManager>();
            }
            return instance;
        }
    }
    public Personagem suaPersonagem;
    public void CriarPersonagem(int cabelo, int roupa, int sapato){
        suaPersonagem = new Personagem("Lisa", cabelo, roupa, sapato);
    }

}

[System.Serializable]
public class Personagem{
    public string nomeDaPersonagem;
    public int cabelo;
    public int roupa;
    public int sapato;

    public Personagem(string _nome, int _cabelo, int  _roupa, int _sapato){
        nomeDaPersonagem = _nome;
        cabelo = _cabelo;
        roupa = _roupa;
        sapato = _sapato;
    }
}
