using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour{
    
    public Transform target;
    private NavMeshAgent myAgent; 
    
    void Start(){
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        myAgent.SetDestination(target.position);
    }

}