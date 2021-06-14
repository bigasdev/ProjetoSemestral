using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeLogin : MonoBehaviour
{
   MainMenu menu;
   public Login login;
   public AudioClip menuClick;
   public void Initialize(MainMenu _menu){
       menu = _menu;
   }
   
   public void LogarConta(){
       SoundManager.Instance.PlaySfx(menuClick);
       Voltar();
       login.CallLogin();
   }
   public void Voltar(){
       SoundManager.Instance.PlaySfx(menuClick);
       menu.menuCompleto.SetActive(true);
   }
   public void Sair(){
       SoundManager.Instance.PlaySfx(menuClick);
       menu.menuCompleto.SetActive(true);
       Destroy(this.gameObject);
   }
}
