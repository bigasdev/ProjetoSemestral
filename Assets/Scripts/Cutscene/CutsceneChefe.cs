using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CutsceneChefe : Cutscene
{
    public static event Action onComplete = delegate {};
    public Transform fantasma1, fantasma2, fantasma3, chefe;
    public Transform fantasma1Trajeto, fantasma2Trajeto, fantasma3Trajeto;
    public GameObject dialogo;
    public DialogoObject dialogoObject;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.Light(false, true),
            Act.Move(fantasma1, fantasma1Trajeto, 3f, false),
            Act.Light(true, true),
            Act.Move(fantasma2, fantasma2Trajeto, 3f, false),
            Act.Light(false, true),
            Act.Move(fantasma3, fantasma3Trajeto, 3f, false),
            Act.Light(true, true),
            Act.Wait(3f)
        };
    }
    protected override void OnExit()
    {
        onComplete();
        chefe.parent = null;
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("", "", null, dialogoObject);
        base.OnExit();
    }
}
