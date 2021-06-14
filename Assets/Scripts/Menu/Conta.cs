using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class Conta : MonoBehaviour
{
    private static Conta instance;
    public static Conta Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Conta>();
            }
            return instance;
        }
    }
    public static string username;
    public int score, cabelo, roupa, sapato;
    public RawImage avatarImage;
    public TextMeshProUGUI playerName;
    public Texture2D image;
    public bool logado => username != null;
    public bool criouPersonagem;
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LogOut(){
        username = null;
        playerName.text = "Sem usuario";
        avatarImage.texture = null;
    }
    public void OnLogin(){
        playerName.text = Conta.username;
        //avatarImage.sprite = avatares[avatar];
        EvaluateValue();
        PersonagemManager.Instance.CriarPersonagem(cabelo, roupa, sapato);
    }
    public void CallSaveData(int _cabelo, int _roupa, int _sapato){
        StartCoroutine(SavePlayerData(_cabelo, _roupa, _sapato));
        cabelo = _cabelo;
        roupa = _roupa;
        sapato = _sapato;
    }
    IEnumerator SavePlayerData(int cabelo, int roupa, int sapato){
        WWWForm form = new WWWForm();
        form.AddField("name", Conta.username);
        form.AddField("cabelo", cabelo);
        form.AddField("roupa", roupa);
        form.AddField("sapato", sapato);
        using(var w = UnityWebRequest.Post("http://localhost/ProjetoSemestral/savedata.php", form)){
            yield return w.SendWebRequest();
            if(w.result != UnityWebRequest.Result.Success){
                print(w.downloadHandler.text);
            }
            else{
            }
        }
    }
    public void AlterarFoto(){
        avatarImage.texture = image;
    }
    void EvaluateValue(){
        var c = cabelo.ToString();
        var index = c[0].ToString();
        cabelo = int.Parse(index);
        var r = roupa.ToString();
        var rIndex = r[0].ToString();
        roupa = int.Parse(rIndex);
        var s = sapato.ToString();
        var sIndex = s[0].ToString();
        sapato = int.Parse(sIndex);
    }
}
