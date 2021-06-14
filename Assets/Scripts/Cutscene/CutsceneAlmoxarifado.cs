using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneAlmoxarifado : Cutscene
{
    public Transform npc;
    public Transform npcGoal;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.Wait(1f),
            Act.Move(npc, npcGoal, .15f, true),
            Act.Wait(1f)        
        };
    }
    protected override void OnExit()
    {
        npc.transform.parent = null;
        Engine.Instance.notifications.CreateNotification("Fale com o funcionario");
        base.OnExit();
    }
}
