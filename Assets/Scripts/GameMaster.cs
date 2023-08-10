using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    public int numPlayers;
    public int fieldExtent;
    public GameObject Player;

    void Start(){
        for(int i = 0; i < numPlayers; i++) Instantiate(Player,validVector(),Quaternion.identity);
    }

    Vector3 validVector(){
        while(true){
            float x = Random.Range(-fieldExtent,fieldExtent);
            float y = 0f;
            float z = Random.Range(-fieldExtent,fieldExtent);
            Vector3 checkedVector = new Vector3(x,y,z);
            if(Physics.OverlapSphere(checkedVector, 0).Length == 0) return checkedVector;
        }
    }

}