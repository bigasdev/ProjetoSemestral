using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class MenuLogado : MonoBehaviour
{
   MainMenu menu;
   public RawImage avatarImage;
   public TextMeshProUGUI nameTitle, minorName, score;
   public GameObject selecionarImgMenu;
   public TMP_InputField urlDaImg;
   public AudioClip menuClick;
   Texture2D img;
   string urlTest = "https://images7.alphacoders.com/360/thumb-1920-360077.jpg";

   public void Initialize(MainMenu _menu){
       menu = _menu;
       //avatarImage.sprite = Conta.Instance.avatares[Conta.Instance.avatar];
       nameTitle.text = $"{"Bem vindo " + Conta.username}";
       minorName.text = $"{"Nome: " + Conta.username}";
       score.text = $"{"Pontuação: " + Conta.Instance.score}";
       avatarImage.texture = Conta.Instance.image;
       if(avatarImage.texture != null){
           selecionarImgMenu.SetActive(false);
       }
   }   
   public void Voltar(){
       SoundManager.Instance.PlaySfx(menuClick);
       menu.menuCompleto.SetActive(true);
       Destroy(this.gameObject);
   }
   public void Sair(){
       SoundManager.Instance.PlaySfx(menuClick);
       Conta.Instance.LogOut();
       Voltar();
   }
   public void Confirma(){
       StartCoroutine(TryImage());
       selecionarImgMenu.SetActive(false);
   }
   IEnumerator TryImage(){
       using(var w = UnityWebRequestTexture.GetTexture(urlDaImg.text)){
           yield return w.SendWebRequest();
           if(w.result != UnityWebRequest.Result.Success){
               print(w.downloadHandler.error);
           }else{
               avatarImage.texture = ((DownloadHandlerTexture)w.downloadHandler).texture;
               Conta.Instance.image = ((DownloadHandlerTexture)w.downloadHandler).texture;
               Conta.Instance.AlterarFoto();
           }
       }
   }
}
