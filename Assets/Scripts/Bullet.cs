using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public float speed;
    public float maxSpeed;
    public float range;

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
        if(hasGetData && rb.velocity.magnitude < maxSpeed){
            rb.AddForce(forward * speed);
        }
        if(rangeOut()){
            Destroy(this.gameObject);
        }
    }

    bool rangeOut(){
        float distance = Vector3.Distance(forward,this.transform.position);
        if(distance > range) return true;
        return false;
    }

}