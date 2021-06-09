using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, characterSelect;
    public GameObject menuCompleto;

    public void IniciarJogo(){
        mainMenu.SetActive(false);
        characterSelect.SetActive(true);
    }
    public void Voltar(GameObject _object){
        mainMenu.SetActive(true);
        _object.SetActive(false);
    }

    public void AbrirConta(){
        menuCompleto.SetActive(false);
        if(!Conta.Instance.logado){
            var loginMenu = Resources.Load<MenuDeLogin>("Prefabs/Menus/MenuDeLogin");
            var menu = Instantiate(loginMenu);
            menu.Initialize(this);
        }
        else
        {
            var logadoMenu = Resources.Load<MenuLogado>("Prefabs/Menus/MenuDeLogado");
            var menu = Instantiate(logadoMenu);
            menu.Initialize(this);
        }
    }
}
