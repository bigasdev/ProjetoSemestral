using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class Registro : MonoBehaviour
{
    [SerializeField] TMP_InputField  nameField;
    [SerializeField] TMP_InputField passwordField;

    [SerializeField] Button submitButton;
    public AudioClip menuClick;
    private void Start() {
        submitButton.onClick.AddListener(CallRegister);
    }
    void CallRegister(){
        SoundManager.Instance.PlaySfx(menuClick);
        StartCoroutine(Register());
    }
    IEnumerator Register(){
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        Debug.Log("form created: " + nameField.text + passwordField.text);
        using(var w = UnityWebRequest.Post("http://localhost/ProjetoSemestral/register.php", form)){
            yield return w.SendWebRequest();
            if(w.result != UnityWebRequest.Result.Success){
                print(w.error);
            }
            else{
                print("New user created");
                nameField.text = null;
                passwordField.text = null;
            }
        }
    }
}
