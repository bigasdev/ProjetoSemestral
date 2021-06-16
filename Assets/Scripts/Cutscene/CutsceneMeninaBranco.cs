using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneMeninaBranco : Cutscene
{
    public Transform npc;
    public Transform npcGoal;
    public AudioClip clipSound;
    public GameObject cutscene;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.Wait(1f),
            Act.PlaySound(clipSound, false),
            Act.Move(npc, npcGoal, .15f, true),      
        };
    }
    protected override void OnExit()
    {
        Engine.Instance.SetNight();
        Instantiate(cutscene);
        base.OnExit();
    }
}
