using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    public int explosionTime;

    private float timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= explosionTime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            // PLAY DESTROY OBJECT ANIMATION HERE
        }

        if (collision.gameObject.tag == "Bomb")
        {
            // CALL BOMB EXPLODE FUNCTION
            collision.gameObject.GetComponent<Bomb>().explode();
        }

        //if (collision.gameObject.tag == "Player")
        //{
        //    // CALL GAME OVER SEQUENCE

        //    Destroy(collision.gameObject);
        //}
    }

}
