using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1f;
    public float rotationSpeed = 180f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * Vector3.up * Mathf.Sin(speed * Time.time);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision par){
        if(par.gameObject.CompareTag("Player")) print("this");
    }
}
