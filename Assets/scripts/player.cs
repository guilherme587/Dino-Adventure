using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float vida = 5;
    public float vel = 5;
    public float forcaDoPulo = 5;
    public float jumps = 1;

    private float _jumps;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    GameObject myObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myObject = GameObject.Find("Square");
        sprite = myObject.GetComponent<SpriteRenderer>();
        _jumps = jumps;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida > 0){
            move();
        }      
    }

    private void move(){
        float x = Input.GetAxisRaw("Horizontal");
        if(x != 0) transform.localScale = new Vector3(x, 1, 1);
        rb.velocity = new Vector2(x * vel, rb.velocity.y);
        
        if(jumps > 0){
            if(Input.GetButtonDown("Jump")){
                jumps--;
                rb.velocity = new Vector2(rb.velocity.x, forcaDoPulo);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D par){
        if(par != null){
            if(par.gameObject.CompareTag("chao") || par.gameObject.CompareTag("parede")) jumps = _jumps;
            if(par.gameObject.CompareTag("inimigo")) Destroy(par.gameObject);//par.gameObject.morte();
        }
    }

    private void OnTriggerEnter2D(Collider2D par) {
        if(par != null){
            if(par.gameObject.CompareTag("item")) Destroy(par.gameObject);
        }
    }

    public void hited(float dano){
        vida -= dano;
        print(dano);
    }
}
