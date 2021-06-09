using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneTeste : Cutscene
{
    [SerializeField] RectTransform primeiraLayer, segundaLayer, terceiraLayer;
    [SerializeField] RectTransform primeiroMovimento, segundoMovimento, terceiroMovimento;
    [SerializeField] RectTransform primeiroIntermediario, segundoIntermediario, terceiroIntermediario;
    protected override void InitializeSequence()
    {
        sequence = new List<CutsceneCommand>(){
            Act.Wait(1f),
            Act.Move(primeiraLayer, primeiroMovimento, 1.5f),
            Act.Move(primeiraLayer, primeiroIntermediario, 2.25f, false),
            Act.Move(segundaLayer, segundoMovimento, 2f),
            Act.Move(segundaLayer, segundoIntermediario, 2.55f, false),
            Act.Move(terceiraLayer, terceiroMovimento, 2.75f),
            Act.Move(terceiraLayer, terceiroIntermediario, 2.75f, false),
            Act.Wait(1f)
        };
    }
}
