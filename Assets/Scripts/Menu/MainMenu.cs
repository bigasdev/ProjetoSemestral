using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, characterSelect, menuRanking;
    public GameObject menuCompleto;
    public AudioClip menuClick, ambientSound;

    private void Start() {
        SoundManager.Instance.PlayAmbient(ambientSound);
    }

    public void IniciarJogo(){
        SoundManager.Instance.PlaySfx(menuClick);
        if(!Conta.Instance.logado){
            mainMenu.SetActive(false);
            characterSelect.SetActive(true);
        }
        else if(Conta.Instance.criouPersonagem){
            SceneManager.LoadScene(1);
        }
        else if(!Conta.Instance.criouPersonagem){
            mainMenu.SetActive(false);
            characterSelect.SetActive(true);
        }
    }
    public void AbrirRanking(){
        SoundManager.Instance.PlaySfx(menuClick);
        var menu = Instantiate(menuRanking);
        menu.GetComponent<MenuRanking>().Initialize(this);
        mainMenu.SetActive(false);
    }
    public void Voltar(GameObject _object){
        SoundManager.Instance.PlaySfx(menuClick);
        mainMenu.SetActive(true);
        _object.SetActive(false);
    }

    public void AbrirConta(){
        SoundManager.Instance.PlaySfx(menuClick);
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
