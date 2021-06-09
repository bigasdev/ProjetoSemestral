using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeLogin : MonoBehaviour
{
   MainMenu menu;

   public void Initialize(MainMenu _menu){
       menu = _menu;
   }
   
   public void LogarConta(){
       Conta.Instance.logado = true;
       Voltar();
   }
   public void Voltar(){
       menu.menuCompleto.SetActive(true);
       Destroy(this.gameObject);
   }
}
