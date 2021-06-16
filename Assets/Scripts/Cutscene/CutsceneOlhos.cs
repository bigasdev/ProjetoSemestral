using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneOlhos : Cutscene
{
    public AudioClip clipSound;
    public GameObject cutscene;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.PlaySound(clipSound, false),
            Act.Wait(4f)   
        };
    }
    protected override void OnExit()
    {
        Instantiate(cutscene);
        base.OnExit();
    }
    protected override void Awake()
    {
        base.Awake();
        var hud = FindObjectOfType<Gamehud>();
        Destroy(hud.gameObject);
        var player = FindObjectOfType<Player>();
        Destroy(player.gameObject);
    }
}
