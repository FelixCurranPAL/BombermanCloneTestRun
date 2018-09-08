using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public int bombtime = 5;

    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        Destroy(gameObject, bombtime);
    }

    void OnTriggerExit2D ()
    {
        gameObject.GetComponent<Collider2D>().isTrigger =  false;
    }

}
