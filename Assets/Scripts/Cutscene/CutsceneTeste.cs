using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CutsceneTeste : Cutscene
{
    public static event Action onComplete = delegate {};
    public GameObject cutsceneMenina;
    [SerializeField] RectTransform primeiraLayer, segundaLayer, terceiraLayer;
    [SerializeField] RectTransform primeiroMovimento, segundoMovimento, terceiroMovimento;
    [SerializeField] RectTransform primeiroIntermediario, segundoIntermediario, terceiroIntermediario;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.Wait(5f)
        };
    }
    protected override void OnExit()
    {
        onComplete();
        Instantiate(cutsceneMenina);
        base.OnExit();
    }
}
