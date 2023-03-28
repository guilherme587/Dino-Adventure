using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 3f;
    public float dano = 2;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = startPos + amplitude * Vector3.up * Mathf.Sin(speed * Time.time);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y < transform.position.y) other.gameObject.GetComponent<player>().hited(dano, 1f);
    }
}
