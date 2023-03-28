using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float vida = 5;
    public float vel = 5;
    public float forcaDoPulo = 5;
    public float jumps = 1;
    public float dano = 1;
    public Animator anim;

    private float _jumps;
    private Rigidbody2D rb;
    private bool escada = false;

    public enum animStates{
        idle, walk, run, jumping, hit, hitted, donw
    }
    public animStates animState = animStates.idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print(rb.gravityScale);
        _jumps = jumps;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida > 0){
            move();
        }
        else animState = animStates.hitted;
        animacao();
    }

    private void move(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0){
            if(x > 0) GetComponent<SpriteRenderer>().flipX = false; else GetComponent<SpriteRenderer>().flipX = true;
            animState = animStates.walk;
        }
        else animState = animStates.idle;
        if(!escada) rb.velocity = new Vector2(x * vel, rb.velocity.y);
        else rb.velocity = new Vector2(x * vel, y * vel);
        
        if(jumps > 0){
            if(Input.GetButtonDown("Jump")){
                jumps--;
                rb.velocity = new Vector2(rb.velocity.x, forcaDoPulo);
                animState = animStates.jumping;
            }
        }
        // if(Input.GetButtonDown("Run")){
        //     print("run");
        //     animState = animStates.run;
        // }
        // if(Input.GetButtonDown("Abaixar")){
        //     print("abaixar");
        //     animState = animStates.donw;
        // }
    }

    private void animacao(){
        if(rb.velocity.y > 2) animState = animStates.jumping;
        foreach(AnimatorControllerParameter i in anim.parameters) if(i.type == AnimatorControllerParameterType.Bool) anim.SetBool(i.name, false);
        switch(animState){
            case animStates.idle:
                anim.SetBool("walk", false);
                break;
            case animStates.walk:
                anim.SetBool("walk", true);
                break;
            case animStates.run:
                anim.SetBool("run", true);
                break;
            case animStates.jumping:
                anim.SetBool("jumping", true);
                break;
            case animStates.hit:
                break;
            case animStates.hitted:
                anim.SetBool("hitted", true);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D par){
        if(par != null){
            if(par.gameObject.CompareTag("chao") || par.gameObject.CompareTag("parede")){
                jumps = _jumps;
                animState = animStates.idle;
            }
            if(par.gameObject.CompareTag("inimigo") && transform.position.y > par.gameObject.transform.position.y){
                Destroy(par.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, forcaDoPulo); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D par) {
        if(par != null){
            if(par.gameObject.CompareTag("item")) Destroy(par.gameObject);
            if(par.gameObject.CompareTag("escada")){
                rb.gravityScale  = 0f;
                escada = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other != null){
            if(other.gameObject.CompareTag("escada")){
                rb.gravityScale  = 1f;
                escada = false;
            }
        }
    }

    public void hited(float dano, float x){
        vida -= dano;
        rb.velocity = new Vector2(x * forcaDoPulo, forcaDoPulo);
    }
}
