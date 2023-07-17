using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public float speed;

    private bool hasGetData = false;
    private Vector3 forward;
    Rigidbody rb;

    public void setVector(Vector3 playerForward){
        this.forward = playerForward;
        hasGetData = true;
    }

    void Start(){
        rb = this.GetComponent<Rigidbody>();
    }

    void Update(){
        if(hasGetData){
            rb.AddForce(forward * speed);
        }
    }

}