using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    public int numPlayers;
    public int fieldExtent;
    public GameObject Player;

    void Start(){
        for(int i = 0; i < numPlayers; i++){
            float x = Random.Range(-fieldExtent,fieldExtent);
            float y = 0f;
            float z = Random.Range(-fieldExtent,fieldExtent);
            Instantiate(Player,new Vector3(x,y,z),Quaternion.identity);
        }
    }

}