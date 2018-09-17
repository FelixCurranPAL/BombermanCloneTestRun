using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public int bombtime = 5;

    private float timer;

    void Start ()
    {
        //Destroy(gameObject, bombtime);
    }

    // Update is called once per frame
    void Update ()
    {
        //compare current time to captured start time
        //once five seconds passes, call explosion method
        timer += Time.deltaTime;
        
        if (timer >= bombtime)
        {
            explode();
        }
    }

    void OnTriggerExit2D ()
    {
        gameObject.GetComponent<Collider2D>().isTrigger =  false; // allows players to walk through bomb while on top of it
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // makes the bomb impassable and immovable
    }


    void explode()
    {


        Destroy(gameObject);
    }

}
