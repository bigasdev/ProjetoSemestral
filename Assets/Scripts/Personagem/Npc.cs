using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Npc : Interactable
{
    public string nome;
    public estiloDoPersonagem estilo;
    public string fala;
    public DialogoObject dialogoObject;
    public Vector2 destino;
    public Sprite[] modelosMasculinos;
    public Sprite[] modelosFemininos;
    public SpriteRenderer npcSprite;
    bool mulher;
    Interactable interactable;
    Vector2 wanderRight, wanderLeft;
    Rigidbody2D rb;
    public List<Vector2> possibleDestinos;
    Coroutine walk;
    int destinoRandom;
    Vector2 realDestino => possibleDestinos[destinoRandom];
    public bool talking;
    public static event Action onTalk = delegate { };
    private void Start() {
        Initialize();
    }
    public override void Action()
    {
        onTalk();
        var d = Instantiate(dialogo);
        d.GetComponent<Dialogo>().Initialize(nome, fala, this, dialogoObject != null ? dialogoObject : null);
        StopAllCoroutines();
        walk = null;
        Desinteract();
    }
    public virtual void Initialize(){
        SetCharacter();
        GetNode();
        rb = GetComponent<Rigidbody2D>();
        interactable = GetComponent<Interactable>();
    }
    private void Update() {
        if(talking) return;
        if(walk == null)walk = StartCoroutine(Walk());
    }

    public virtual void SetCharacter(){
        var sexo = UnityEngine.Random.Range(0, 2);
        if(sexo == 1) mulher = true;
        else mulher = false;

        var _nome = UnityEngine.Random.Range(0, 21);
        var spritesMasculino = UnityEngine.Random.Range(0, modelosMasculinos.Length - 1);
        var spritesFeminino = UnityEngine.Random.Range(0, modelosFemininos.Length - 1);

        if(mulher){
            npcSprite.sprite = modelosFemininos[spritesFeminino];
            nome = NomesFactory.nomesFemininos[_nome];
        }
        else{
            npcSprite.sprite = modelosMasculinos[spritesMasculino];
            nome = NomesFactory.nomesMasculinos[_nome];
        }

        var _estilo = UnityEngine.Random.Range(0, 2);
        if(_estilo == 1) estilo = estiloDoPersonagem.CURIOSO;
        else estilo = estiloDoPersonagem.APRESSADO;

        if(estilo == estiloDoPersonagem.CURIOSO){
            var _fala = UnityEngine.Random.Range(0, DialogosFactory.dialogosAmigaveis.Count);
            fala = DialogosFactory.dialogosAmigaveis[_fala];
        }
        else{
            var _fala = UnityEngine.Random.Range(0, DialogosFactory.dialogosPressa.Count);
            fala = DialogosFactory.dialogosPressa[_fala];    
        }
    }
    void GetNode(){
        var grid = FindObjectOfType<Grid>();
        foreach(Node node in grid.grid){
            if(!node.isWall && Vector2.Distance(transform.position, node.position) < 2){
                destino = node.position;
                foreach(Node n in grid.GetNeighboringNodes(node)){
                    possibleDestinos.Add(n.position);
                }
            }
        }
        destinoRandom = UnityEngine.Random.Range(0, possibleDestinos.Count - 1);
    }
    IEnumerator Walk(){
        while(Vector2.Distance(transform.position, realDestino) > .15f){
            transform.position = Vector2.MoveTowards(transform.position, realDestino, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.25f);
        GetNode();
        yield return walk = null;
    }
}

public class NomesFactory{
    public static Dictionary<int, string> nomesMasculinos = new Dictionary<int, string>{
        {0, "João"},
        {1, "Felipe"},
        {2, "Antonio"},
        {3, "Ricardo"},
        {4, "José"},
        {5, "Gustavo"},
        {6, "Alex"},
        {7, "Alexandre"},
        {8, "Eduardo"},
        {9, "Murilo"},
        {10, "Nathan"},
        {11, "Guilherme"},
        {12, "Leonardo"},
        {13, "Bruno"},
        {14, "Mauricio"},
        {15, "Teo"},
        {16, "Pedro"},
        {17, "Osmar"},
        {18, "Miguel"},
        {19, "Otto"},
        {20, "Renato"}
    };

    public static Dictionary<int, string> nomesFemininos = new Dictionary<int, string>{
        {0, "Maria"},
        {1, "Gabriele"},
        {2, "Julia"},
        {3, "Ana"},
        {4, "Carol"},
        {5, "Livia"},
        {6, "Agatha"},
        {7, "Camila"},
        {8, "Natasha"},
        {9, "Catarina"},
        {10, "Sara"},
        {11, "Beatriz"},
        {12, "Bianca"},
        {13, "Thais"},
        {14, "Lilian"},
        {15, "Emilly"},
        {16, "Leticia"},
        {17, "Ingrid"},
        {18, "Ofélia"},
        {19, "Bárbara"},
        {20, "Giulia"}
    };
}

public class DialogosFactory{
    public static Dictionary<int, string> dialogosAmigaveis = new Dictionary<int, string>{
        {0, "Hoje vou experimentar o burguer king!"},
        {1, "Vou comprar os lanches!"},
        {2, "Estou com fome!"},
        {3, "Que vontade de tomar um suco!"},
        {4, "Vamos comer no restaurante?"},
        {5, "Queria um doce hoje!"},
        {6, "Você vai no evento?!"},
        {7, "Vim comprar um cosplay!"},
        {8, "Amei esse cosplay!"},
        {9, "Vamos na fantasy?"},
        {10, "Onde é o banheiro?"},
        {11, "Vamos ver as lojas!"},
        {12, "Que shopping bonito!"},
        {13, "As lanternas são lindas!"}
    };
    public static Dictionary<int, string> dialogosPressa = new Dictionary<int, string>{
        {0, "Vou ir comer algo!"},
        {1, "Vou ao banheiro!"},
        {2, "Vou passear!"},
        {3, "Quero ir embora!"},
        {4, "Graças a deus é sexta-feira!"}
    };
}
public enum estiloDoPersonagem{
    CURIOSO,
    APRESSADO
}
