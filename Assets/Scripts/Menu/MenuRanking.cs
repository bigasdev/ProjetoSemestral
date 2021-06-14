using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class MenuRanking : MonoBehaviour
{
    private static MenuRanking instance;
    public static MenuRanking Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<MenuRanking>();
            }
            return instance;
        }
    }
    MainMenu menu;
    public TextMeshProUGUI primeiroNome;
    public TextMeshProUGUI primeiroScore;
    public Button voltar;
   public void Initialize(MainMenu _menu){
       menu = _menu;
       voltar.onClick.AddListener(Voltar);
       StartCoroutine(Getranking());
   }
   public void Voltar() => menu.Voltar(this.gameObject);

    public void CallRegister(string nome, int score){
        StartCoroutine(Register(nome, score));
    }
    IEnumerator Register(string nome, int score){
        WWWForm form = new WWWForm();
        form.AddField("name", nome);
        form.AddField("score", score);
        using(var w = UnityWebRequest.Post("http://localhost/ProjetoSemestral/addScore.php", form)){
            yield return w.SendWebRequest();
            if(w.result != UnityWebRequest.Result.Success){
                print(w.error);
            }
            else{
                print("New user created");
            }
        }
    }
    IEnumerator Getranking(){
            using(var w = UnityWebRequest.Get("http://localhost/ProjetoSemestral/displayScore.php")){
            yield return w.SendWebRequest();
            if(w.result != UnityWebRequest.Result.Success){
                print(w.error);
            }
            else{
                primeiroNome.text = w.downloadHandler.text;
            }
        }  
    }
}
