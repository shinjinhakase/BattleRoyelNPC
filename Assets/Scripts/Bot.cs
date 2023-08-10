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
    private bool isCoolComplete;
    
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
        if(isEnemyInsight() && getDistanceToEnemy() < range){
            myAgent.speed = 0;
        }else{
            myAgent.speed = initSpeed;
        }
    }

    bool isEnemyInsight(){
        RaycastHit[] hits;
        hits = Physics.RaycastAll(this.transform.position,transform.forward,100.0f);
        if(isInclude(hits,"Block")) return false;
        if(isInclude(hits,"Player")) return true;
        return false;
    }

    bool isInclude(RaycastHit[] hits,string tag){
        foreach(RaycastHit hit in hits){
            if(hit.collider.gameObject.tag == tag){
                return true;
            }
        }
        return false;
    }

    void cool(){
        coolTimeCount++;
        if(coolTimeCount > coolTime){
            isCoolComplete = true;
            coolTimeCount = 0;
        }else{
            isCoolComplete = false;
        }
    }

    void shot(){
        aiming();
        if(getDistanceToEnemy() > range) return;
        if(!isEnemyInsight()) return;
        if(!isCoolComplete) return;
        gun.shot(transform.forward);
    }

    float getDistanceToEnemy(){
        return Vector3.Distance(this.transform.position,target.position);
    }

    void aiming(){
        transform.LookAt(target);
    }

}