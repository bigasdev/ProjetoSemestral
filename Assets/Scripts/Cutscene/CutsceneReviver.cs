using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneReviver : Cutscene
{
    public AudioClip clipSound;
    public GameObject dialogo;
    public DialogoObject dialogoObject;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.PlaySound(clipSound, false), 
        };
    }
    protected override void OnExit()
    {
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize("", "", null, dialogoObject);
        base.OnExit();
    }
}
