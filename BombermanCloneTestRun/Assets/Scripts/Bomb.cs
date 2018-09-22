using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public int bombTime;

    public GameObject centreExplosion;
    public GameObject horizontalConnectingExplosion;
    public GameObject verticalConnectingExplosion;
    public GameObject leftEndExplosion;
    public GameObject rightEndExplosion;
    public GameObject upEndExplosion;
    public GameObject downEndExplosion;

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
        
        if (timer >= bombTime)
        {
            explode();
        }
    }

    void OnTriggerExit2D ()
    {
        gameObject.GetComponent<Collider2D>().isTrigger =  false; // allows players to walk through bomb while on top of it
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true; // makes the bomb impassable and immovable
    }


    public void explode()
    {
        int bombStrength = PlayerController.bombStrength;
        var pos = transform.position;

        Instantiate(centreExplosion, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);

        for (int i = 1; i <= bombStrength; i++)
        {
            if (i < bombStrength)
            {
                Instantiate(horizontalConnectingExplosion, new Vector3(Mathf.RoundToInt(pos.x - i), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);
                Instantiate(horizontalConnectingExplosion, new Vector3(Mathf.RoundToInt(pos.x + i), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);
                Instantiate(verticalConnectingExplosion, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y - i), pos.z), Quaternion.identity);
                Instantiate(verticalConnectingExplosion, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y + i), pos.z), Quaternion.identity);
            }

            if (i == bombStrength)
            {
                Instantiate(leftEndExplosion, new Vector3(Mathf.RoundToInt(pos.x - i), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);
                Instantiate(rightEndExplosion, new Vector3(Mathf.RoundToInt(pos.x + i), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);
                Instantiate(upEndExplosion, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y + i), pos.z), Quaternion.identity);
                Instantiate(downEndExplosion, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y - i), pos.z), Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }

}
