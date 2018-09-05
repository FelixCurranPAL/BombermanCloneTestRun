using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {
    public int bombtime = 5;
    public Collider2D playerCollider;
    public Collider2D bombCollider;
    public Collider2D test;

    void Start () {
    test = GetComponent<Collider2D>();
        test.isTrigger = true;
}

// Update is called once per frame
    void Update () {

        Destroy(gameObject, bombtime);
        if(test.isTrigger == false){
            Physics2D.IgnoreCollision(playerCollider, bombCollider);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        test.isTrigger = false;
    }

}
