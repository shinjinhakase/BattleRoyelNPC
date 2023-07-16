using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour{
    
    public Transform target;
    private NavMeshAgent myAgent;

    public GameObject bullet;
    public float range;

    private float initSpeed;
    
    void Start(){
        myAgent = GetComponent<NavMeshAgent>();
        initSpeed = myAgent.speed;
    }

    void Update(){
        myAgent.SetDestination(target.position);
        distanceCheck();
    }

    void distanceCheck(){
        if(getDistanceToEnemy() < range){
            Debug.Log("distance");
            myAgent.speed = 0;
        }else{
            myAgent.speed = initSpeed;
        }
    }

    float getDistanceToEnemy(){
        return Vector3.Distance(this.transform.position,target.position);
    }

}