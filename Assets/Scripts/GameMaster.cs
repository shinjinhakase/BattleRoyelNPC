using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    public int numPlayers;
    public int fieldExtent;
    public GameObject Player;

    List<GameObject> playerList;

    void Start(){
        generatePlayer();
    }

    void generatePlayer(){
        playerList = new List<GameObject>();
        for(int i = 0; i < numPlayers; i++){
            GameObject newPlayer = Instantiate(Player) as GameObject;
            newPlayer.transform.position = validVector();
            playerList.Add(newPlayer);
        }
        //testS
        string debugLog = "";
        foreach(GameObject player in playerList){
            debugLog += "(" + player.transform.position.x.ToString() + "," + player.transform.position.z.ToString() + ")";
        }
        Debug.Log(debugLog);
        //testG
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