using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogo : MonoBehaviour
{
    [SerializeField] Text npcName, npcDialogo;
    [SerializeField] Button skipButton;
    [SerializeField] GameObject opcaoMenu;
    [SerializeField] AudioClip typingSound;
    Npc npc;
    DialogoObject dialogoObject;
    public List<string> dialogos = new List<string>();
    int dialogoIndex = 0;
    Coroutine dialogoSequence;
    public void Initialize(string nome, string dialogo, Npc _npc = null, DialogoObject _dialogo = null){
        npcName.text = nome;
        npc = _npc;
        dialogoObject = _dialogo;
        BuildDialogos();
        if(dialogo != "")dialogos.Add(dialogo);
        if(npc != null)npc.talking = true;
        if(dialogoSequence == null)dialogoSequence = StartCoroutine(dialogoBehaviour(dialogos[0]));
        skipButton.onClick.AddListener(SkipDialogo);
        Player.Instance.StopEverything();
    }
    void BuildDialogos(){
        if(dialogoObject != null){
            foreach(string fala in dialogoObject.falas){
                dialogos.Add(fala);
            }
        }
    }
    IEnumerator dialogoBehaviour(string dialogo){
        Engine.Instance.currentState = States.DIALOGO;
        npcDialogo.text = "";
        if(dialogoObject != null){
            if(dialogoObject.talkSound.Length > 0) SoundManager.Instance.PlayOst(dialogoObject.talkSound[dialogoIndex]);
        }
        foreach(char c in dialogo){
            npcDialogo.text += c;
            if(!SoundManager.Instance.sfx.isPlaying)SoundManager.Instance.PlaySfx(typingSound);
            yield return new WaitForSeconds(0.0585f);
        }
        yield return new WaitForSeconds(1f);
        dialogoIndex++;
        dialogoSequence = null;
        if(dialogoIndex == dialogos.Count){
            Engine.Instance.currentState = States.GAME_UPDATE;
            if(npc != null)npc.talking = false;
            if(dialogoObject != null){
                if(dialogoObject.opcao == true){
                    var o = Instantiate(opcaoMenu);
                    o.GetComponent<Escolha>().Initialize(dialogoObject.opcoes[0], dialogoObject.opcoes[1],
                                                         dialogoObject.proximos[0], dialogoObject.proximos[1]);
                }
                if(dialogoObject.missaoPraPegar != ""){
                    foreach(Mission m in Engine.Instance.missionsContainer[dialogoObject.missaoPraPegar].Values){
                        Engine.Instance.notifications.CreateNotification("Novas tarefas");
                        Player.Instance.currentMissions.Add(m);
                        FindObjectOfType<Gamehud>().RefreshTab(Player.Instance.currentMissions);
                        m.objetivo.AddObjetivo();
                    }
                }
            }
            Destroy(this.gameObject);
        }
        else{
            StartCoroutine(dialogoBehaviour(dialogos[dialogoIndex]));
        }
    }
    void SkipDialogo(){
        SoundManager.Instance.StopOst();
        dialogoIndex++;
        if(dialogoIndex == dialogos.Count){
            Engine.Instance.currentState = States.GAME_UPDATE;
            if(npc != null)npc.talking = false;
            if(dialogoObject != null){
                if(dialogoObject.opcao == true){
                    var o = Instantiate(opcaoMenu);
                    o.GetComponent<Escolha>().Initialize(dialogoObject.opcoes[0], dialogoObject.opcoes[1],
                                                         dialogoObject.proximos[0], dialogoObject.proximos[1]);
                }
                if(dialogoObject.missaoPraPegar != ""){
                    foreach(Mission m in Engine.Instance.missionsContainer[dialogoObject.missaoPraPegar].Values){
                        Engine.Instance.notifications.CreateNotification("Novas tarefas");                      
                        Player.Instance.currentMissions.Add(m);
                        FindObjectOfType<Gamehud>().RefreshTab(Player.Instance.currentMissions);
                        m.objetivo.AddObjetivo();
                    }
                }
            }
            Destroy(this.gameObject);
        }
        else{
            StopAllCoroutines();
            npcDialogo.text = dialogos[dialogoIndex - 1];
            dialogoSequence = StartCoroutine(dialogoBehaviour(dialogos[dialogoIndex]));
        }
    }
}
