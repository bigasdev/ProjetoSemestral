using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public partial class Cutscene : MonoBehaviour
{
    [SerializeField] States endState;
    [SerializeField] bool fade;
    [SerializeField] Image fadeImage;
    Coroutine sequenceRoutine;
    protected List<CutsceneCommand> sequence;
    public void PlaySequence(){
        if(sequenceRoutine != null) return;
        sequenceRoutine = StartCoroutine(RunSequence());
    }
    protected virtual void InitializeSequence(){
        sequence = new List<CutsceneCommand>();
    }
    IEnumerator RunSequence(){
        if(fade){
            fadeImage.DOFade(1f, 1f);
            yield return new WaitForSeconds(1f);
            fadeImage.DOFade(0f, 1f);
            yield return new WaitForSeconds(1f);
        }
        for(int i = 0; i < sequence.Count; i++){
            Debug.Log("PLAYING COMMAND " + i);
            if(sequence[i].waitUntilComplete){
                yield return StartCoroutine(sequence[i].PlayCommand());
            }
            else{
                StartCoroutine(sequence[i].PlayCommand());
            }
        }
        if(fade){
            fadeImage.DOFade(1f, 1f);
            yield return new WaitForSeconds(1f);  
        }
        OnExit();
    }
    protected virtual void OnExit(){
        Engine.Instance.currentState = endState;
        StopCoroutine(sequenceRoutine);
        Destroy(this.gameObject);
    }
    protected virtual void Awake() {
        InitializeSequence();
        Engine.Instance.currentState = States.CUTSCENE;
        PlaySequence();
    }
}
