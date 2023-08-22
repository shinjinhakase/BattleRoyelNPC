using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    public int numPlayers;
    public int numItems;
    public int footstepsRange;
    public int fieldExtent;
    public GameObject Player;
    public GameObject Item;

    List<GameObject> playerList;

    void Start(){
        generateItem();
        generatePlayer();
    }

    void generateItem(){
        for(int i = 0; i < numItems; i++){
            GameObject newItem = Instantiate(Item) as GameObject;
            newItem.transform.position = validVector();
        }
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
        GameObject nearestPlayer = getNearestPlayer(origin);
        if(Vector3.Distance(origin.transform.position,nearestPlayer.transform.position) < footstepsRange) return nearestPlayer;
        GameObject nearestItem = getNearestItem(origin);
        return nearestItem;
    }

    GameObject getNearestPlayer(GameObject origin){
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

    GameObject getNearestItem(GameObject origin){
        GameObject answer = null;
        float minDistance = fieldExtent * 3;
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Item")){
            float distance = Vector3.Distance(origin.transform.position,item.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                answer = item;
            }
        }
        return answer;
    }

}