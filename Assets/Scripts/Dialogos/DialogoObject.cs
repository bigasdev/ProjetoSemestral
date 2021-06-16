using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogoObject", menuName = "LendaDoBumbumMole/DialogoObject", order = 0)]
public class DialogoObject : ScriptableObject {
    public string nome;
    public AudioClip[] talkSound;
    public string[] falas;
    public bool opcao;
    public string[] opcoes;
    public DialogoObject[] proximos;
    public string missaoPraPegar;
    public bool temCutscene;
    public bool temFinal;
    public bool temChefeFinal;
    public bool temBilhete;
}
