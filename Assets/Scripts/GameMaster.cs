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
            newPlayer.GetComponent<Bot>().setGM(this.GetComponent<GameMaster>());
            playerList.Add(newPlayer);
        }
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

    public GameObject getTarget(GameObject origin){
        GameObject answer = null;
        float minDistance = fieldExtent * 3;
        foreach(GameObject player in playerList){
            if(origin == player) continue;

            float distance = Vector3.Distance(origin.transform.position,player.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                answer = player;
            }
        }
        return answer;
    }

}