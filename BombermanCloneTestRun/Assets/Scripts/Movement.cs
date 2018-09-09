
using UnityEngine;
using System.Timers;
using System;

//using UnityEngine;
//using System.Timers;
//using System;

public class Movement : MonoBehaviour
{
    public GameObject bombPrefab;
    public float speed;

    private bool moving;
    private Rigidbody2D characterRigidbody;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        placeBombs();
        Debug.Log(characterRigidbody.velocity);
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    // Used for all physics based interactions
    void FixedUpdate()
    {
        movement();
        
    }

    void movement()
    {
        characterRigidbody = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey("w"))
        {
            //characterRigidbody.AddForce(transform.up * speed);
            characterRigidbody.velocity = transform.up * speed;
            moving = true;
        }

        if (Input.GetKey("a"))
        {
            //characterRigidbody.AddForce(-transform.right * speed);
            characterRigidbody.velocity = -transform.right * speed;
            moving = true;
        }

        if (Input.GetKey("s"))
        {
            //characterRigidbody.AddForce(-transform.up * speed);
            characterRigidbody.velocity = -transform.up * speed;
            moving = true;
        }

        if (Input.GetKey("d"))
        {
            //characterRigidbody.AddForce(transform.right * speed);
            characterRigidbody.velocity = transform.right * speed;
            moving = true;
        }

        if (moving == true && (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("space")))
        {
            characterRigidbody.velocity = Vector2.zero;
            moving = false;
        }
    }

    void placeBombs()
    {
        var pos = transform.position;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), pos.z), Quaternion.identity);
        }
    }

}


