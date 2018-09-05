
using UnityEngine;
using System.Timers;
using System;

public class Movement : MonoBehaviour
{
    float lastStep, timeBetweenSteps = 0.05f;

    float lastFrame, timeBetweenFrames = 0.25f;
    int animationStep = 0;

    public float movementSpeed = 0.25f;
    public GameObject bombPrefab;
    public Sprite DownIdle, LeftIdle, RightIdle, UpIdle, DownMove1, LeftMove1, RightMove1, UpMove1, DownMove2, LeftMove2, RightMove2, UpMove2;
    public int bombStrength;
    public int bombDuration;
    Transform GetTransform;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        placeBombs();
    }

    void movement()
    {
        var pos = transform.position;

        if (Input.GetKey("w"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.y += movementSpeed;
                transform.position = pos; // TO DO: NEED TO REPLACE WITH GRADUAL MOVEMENT SYSTEM
            }


            if (animationStep < 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = UpMove1;
                    animationStep = animationStep + 1;
                    lastFrame = Time.time;
                }
            }
            else if (animationStep == 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = UpMove2;
                    animationStep = 0;
                    lastFrame = Time.time;
                }


            }
        }

        if (Input.GetKey("a"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.x -= movementSpeed;
                transform.position = pos;
            }


            if (animationStep < 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = LeftMove1;
                    animationStep = animationStep + 1;
                    lastFrame = Time.time;
                }
            }
            else if (animationStep == 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = LeftMove2;
                    animationStep = 0;
                    lastFrame = Time.time;
                }
            }
        }

        if (Input.GetKey("s"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.y -= movementSpeed;
                transform.position = pos;
            }


            if (animationStep < 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = DownMove1;
                    animationStep = animationStep + 1;
                    lastFrame = Time.time;
                }
            }
            else if (animationStep == 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = DownMove2;
                    animationStep = 0;
                    lastFrame = Time.time;
                }
            }
        }

        if (Input.GetKey("d"))
        {

            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                pos.x += movementSpeed;
                transform.position = pos;
            }


            if (animationStep < 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = RightMove1;
                    animationStep = animationStep + 1;
                    lastFrame = Time.time;
                }
            }
            else if (animationStep == 1)
            {
                if (Time.time - lastFrame > timeBetweenFrames)
                {
                    this.GetComponent<SpriteRenderer>().sprite = RightMove2;
                    animationStep = 0;
                    lastFrame = Time.time;
                }
            }
        }
    }

    void placeBombs()
    {
        var pos = transform.position;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bombPrefab, new Vector3(pos.x,pos.y,pos.z), Quaternion.identity);
        }
    }


}
