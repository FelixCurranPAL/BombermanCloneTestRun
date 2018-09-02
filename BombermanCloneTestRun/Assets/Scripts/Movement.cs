using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float lastStep, timeBetweenSteps = 0.05f;
    public float movementSpeed = 0.25f;
    public Sprite moveUp, moveLeft, moveDown, moveRight;
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
                    this.GetComponent<SpriteRenderer>().sprite = moveUp;

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
                    this.GetComponent<SpriteRenderer>().sprite = moveLeft;

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
                    this.GetComponent<SpriteRenderer>().sprite = moveDown;

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
                    this.GetComponent<SpriteRenderer>().sprite = moveRight;

                }
            }
        }
    }
}
