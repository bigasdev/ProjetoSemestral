using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneMeninaBrancoEscritorio : Cutscene
{
    public Transform npc;
    public Transform npcGoal;
    public AudioClip clipSound;
    public GameObject escolhaMenu;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.PlaySound(clipSound, false),
            Act.Move(npc, npcGoal, .15f, true),      
        };
    }
    protected override void OnExit()
    {
        var e = Instantiate(escolhaMenu);
        e.GetComponent<Escolha>().Initialize("Seguir fantasma", "Voltar para a loja", null, null, false);
        Engine.Instance.SetNight();
        base.OnExit();
    }
}
