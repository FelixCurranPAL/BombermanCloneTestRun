using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    float lastStep, timeBetweenSteps = 0.05f;
    public float movementSpeed = 0.25f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        var pos = transform.position;

        if (Input.GetKey("w"))
        {
            if (pos.y <= 3.75)
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    pos.y += movementSpeed;
                    transform.position = pos;
                }
            }
        }

        if (Input.GetKey("a"))
        {
            if (pos.x >= -3.75)
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    pos.x -= movementSpeed;
                    transform.position = pos;
                }
            }
        }

        if (Input.GetKey("s"))
        {
            if (pos.y >= -2.75)
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    pos.y -= movementSpeed;
                    transform.position = pos;
                }
            }
        }

        if (Input.GetKey("d"))
        {
            if (pos.x <= 3.75)
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    pos.x += movementSpeed;
                    transform.position = pos;
                }
            }
        }
    }
}
