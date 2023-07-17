using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;

    public void shot(Vector3 forward){
        GameObject newbullet = Instantiate(bullet) as GameObject;
        newbullet.transform.position = this.transform.position;
        newbullet.GetComponent<Bullet>().setVector(forward);
    }

}