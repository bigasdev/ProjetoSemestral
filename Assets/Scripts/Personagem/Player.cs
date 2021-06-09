using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    float horizontal, vertical;
    [SerializeField] float speed, moveLimiter;
    [SerializeField] LayerMask interactions;
    Rigidbody2D rb;
    Animator anim;
    Transform spriteScale;
    
    Vector2 center => new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    Interactable interaction;
    public List<Mission> currentMissions = new List<Mission>();
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteScale = GetComponentInChildren<Transform>();
    }
    public void StopEverything(){
        horizontal = vertical = 0;
        anim.SetBool("Idle", true);
        anim.SetBool("Side", false);
    }
    private void Update() {
        if(Engine.Instance.currentState != States.GAME_UPDATE) return;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        AnimController();
        LookForInteraction();
    }
    void AnimController(){
        anim.SetFloat("Up", vertical);
        anim.SetBool("Side", horizontal == 0 ? false:true);
        anim.SetBool("Idle", horizontal == 0 && vertical == 0 ? true:false);
        if(horizontal > 0) spriteScale.localScale = new Vector2(-1, 1);
        else spriteScale.localScale = new Vector2(1, 1);
    }
    private void FixedUpdate() {
        if(horizontal != 0 && vertical != 0){
            horizontal *= moveLimiter;  
            vertical *= moveLimiter;
        }
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
    void LookForInteraction(){
        var collider = Physics2D.OverlapCircle(center, 1f, interactions);
        if(collider){
           interaction = collider.GetComponent<Interactable>();
           if(interaction != null) {
               interaction.Interact();
               if(Input.GetKeyDown(KeyCode.E)){
                   interaction.Action();
               }
           }
        }
        else
        {
            if(interaction != null) interaction.Desinteract();
        }
    }
}
