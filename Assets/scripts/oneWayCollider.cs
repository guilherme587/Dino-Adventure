using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayCollider : MonoBehaviour
{
    public PlatformEffector2D effec;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow)) timer = 0.5f;
        if(Input.GetKey(KeyCode.DownArrow)){
            if(timer <= 0){
                effec.rotationalOffset = 180f;
                timer = 0.5f;
            }
            else timer -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump")) effec.rotationalOffset = 0;
    }
}
