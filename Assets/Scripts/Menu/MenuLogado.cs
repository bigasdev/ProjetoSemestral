using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogado : MonoBehaviour
{
   MainMenu menu;

   public void Initialize(MainMenu _menu){
       menu = _menu;
   }   
   public void Voltar(){
       menu.menuCompleto.SetActive(true);
       Destroy(this.gameObject);
   }
}
