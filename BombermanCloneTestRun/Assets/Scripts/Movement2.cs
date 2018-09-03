using UnityEngine;
using System.Timers;
using System;

public class Movement2 : MonoBehaviour
{
    float lastStep, timeBetweenSteps = 0.05f;
    public float movementSpeed = 0.25f;
    public Sprite moveUp, moveUp2, moveUpIdle, moveLeft, moveLeft2, moveLeftIdle, moveDown, moveDown2, moveDownIdle, moveRight, moveRight2, moveRightIdle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        if (Input.GetKey("w"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.y += movementSpeed;
                transform.position = pos;
                this.GetComponent<SpriteRenderer>().sprite = moveUp;


            }
           

        }

        if (Input.GetKeyUp("w"))
        {
            this.GetComponent<SpriteRenderer>().sprite = moveUpIdle;
        }

        if (Input.GetKey("a"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.x -= movementSpeed;
                transform.position = pos;
                this.GetComponent<SpriteRenderer>().sprite = moveLeft;

            }

        }

        if (Input.GetKeyUp("a"))
        {
            this.GetComponent<SpriteRenderer>().sprite = moveLeftIdle;
        }

        if (Input.GetKey("s"))
        {
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

        if (Input.GetKeyUp("s"))
        {
            this.GetComponent<SpriteRenderer>().sprite = moveDownIdle;
        }

        if (Input.GetKey("d"))
            {
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

        if (Input.GetKeyUp("d"))
        {
            this.GetComponent<SpriteRenderer>().sprite = moveRightIdle;
        }

    }

}


