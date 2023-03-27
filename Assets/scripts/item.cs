using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1f;
    public float rotationSpeed = 180f;
    public float gridSize = 1f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        gridPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * Vector3.up * Mathf.Sin(speed * Time.time);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void gridPosition(){
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x / gridSize) * gridSize;
        pos.y = Mathf.Round(pos.y / gridSize) * gridSize;
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D par)
    {
        if(par.gameObject.CompareTag("Player")) print("this");
    }
}
