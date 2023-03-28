using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float vel = 2f;
    public float vida = 1f;
    public float dano = 1f;
    public Animator anim;

    private float x = 1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x * vel, rb.velocity.y);
        rb.transform.localScale = new Vector3(-x, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D outro){
        if(outro.gameObject.CompareTag("parede")) x *= -1f;
        if(outro.gameObject.CompareTag("Player")) outro.gameObject.GetComponent<player>().hited(dano, x);
    }

    void OnDestroy()
    {
        //anim.Play("explosion_Anim");
    }

    public void morte(float dano){
        print(dano);
    }
}
