using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour {
    
    public Transform target;
    public Gun gun;
    public float range;
    public float coolTime;
    
    private NavMeshAgent myAgent;
    private float initSpeed;
    private int coolTimeCount;
    private bool canShot;
    
    void Start(){
        myAgent = GetComponent<NavMeshAgent>();
        initSpeed = myAgent.speed;
    }

    void Update(){
        myAgent.SetDestination(target.position);
        setSpeed();
        cool();
        shot();
    }

    void setSpeed(){
        if(getDistanceToEnemy() > range){
            myAgent.speed = initSpeed;
        }else{
            myAgent.speed = 0;
        }
    }

    void cool(){
        coolTimeCount++;
        if(coolTimeCount > coolTime){
            canShot = true;
            coolTimeCount = 0;
        }else{
            canShot = false;
        }
    }

    void shot(){
        if(getDistanceToEnemy() > range) return;
        if(!canShot) return;

        gun.shot(transform.forward);
    }

    float getDistanceToEnemy(){
        return Vector3.Distance(this.transform.position,target.position);
    }

}