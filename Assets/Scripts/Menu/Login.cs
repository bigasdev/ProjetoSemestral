using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class Login: MonoBehaviour
{
    [SerializeField] TMP_InputField  nameField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] GameObject menu;
    public void CallLogin(){
        StartCoroutine(LoginAction());
    }
    IEnumerator LoginAction(){
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        using(var w = UnityWebRequest.Post("http://localhost/ProjetoSemestral/login.php", form)){
            yield return w.SendWebRequest();
            if(w.result != UnityWebRequest.Result.Success){
                print(w.downloadHandler.text);
            }
            else{
                Conta.username = nameField.text;
                Conta.Instance.score = int.Parse(w.downloadHandler.text.Split('\t')[1]);
                Conta.Instance.cabelo = int.Parse(w.downloadHandler.text.Split('\t')[2]);
                Conta.Instance.roupa = int.Parse(w.downloadHandler.text.Split('\t')[3]);
                Conta.Instance.sapato = int.Parse(w.downloadHandler.text.Split('\t')[4]);
                Conta.Instance.OnLogin();
                Destroy(menu);
            }
        }
    }
}
