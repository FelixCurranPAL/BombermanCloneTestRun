using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public int bombtime = 5;

    void Start ()
    {
        Destroy(gameObject, bombtime);
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    //KICK POWERUP
    // ON COLLISION ENTER, CHECK IF PLAYER HAS KICK POWERUP
    // IF SO, ADD FORCE IN DIRECT OF COLLISION

    void OnTriggerExit2D ()
    {
        gameObject.GetComponent<Collider2D>().isTrigger =  false;
    }

}
