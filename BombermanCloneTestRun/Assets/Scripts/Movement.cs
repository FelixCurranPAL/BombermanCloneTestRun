
using UnityEngine;
using System.Collections.Generic;
using System.Timers;
using System;

public class Movement : MonoBehaviour
{
    public GameObject bombPrefab;
    public float speed;

    private Rigidbody2D characterRigidbody;

    private List<KeyCode> keysPressed = new List<KeyCode>();

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        placeBombs();
    }

    // Used for all physics based interactions
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        characterRigidbody = gameObject.GetComponent<Rigidbody2D>();

        // CHECK IF ANY OF THE CORE MOVEMENT BUTTONS ARE BEING PRESSED, IF THEY ARE THEN ADD THEM TO A LIST
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W) && !keysPressed.Contains(KeyCode.W))
            {
                keysPressed.Add(KeyCode.W);
            }

            if (Input.GetKey(KeyCode.A) && !keysPressed.Contains(KeyCode.A))
            {
                keysPressed.Add(KeyCode.A);
            }

            if (Input.GetKey(KeyCode.S) && !keysPressed.Contains(KeyCode.S))
            {
                keysPressed.Add(KeyCode.S);
            }

            if (Input.GetKey(KeyCode.D) && !keysPressed.Contains(KeyCode.D))
            {
                keysPressed.Add(KeyCode.D);
            }
        }

        // IF ONE OF THE BUTTONS STOPS BEING PRESSED, REMOVE IT FROM THE LIST
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.W))
            {
                keysPressed.Remove(KeyCode.W);
            }

            if (!Input.GetKey(KeyCode.A))
            {
                keysPressed.Remove(KeyCode.A);
            }

            if (!Input.GetKey(KeyCode.S))
            {
                keysPressed.Remove(KeyCode.S);
            }

            if (!Input.GetKey(KeyCode.D))
            {
                keysPressed.Remove(KeyCode.D);
            }
        }

        // IF BUTTONS ARE BEING PRESSED, GRAB THE TOP BUTTON FROM THE LIST AND MOVE THE CHARACTER IN THAT DIRECTION. 
        if (keysPressed.Count > 0)
        {
            if (keysPressed[keysPressed.Count - 1] == KeyCode.W)
            {
                characterRigidbody.velocity = transform.up * speed;
            }

            if (keysPressed[keysPressed.Count - 1] == KeyCode.A)
            {
                characterRigidbody.velocity = -transform.right * speed;
            }

            if (keysPressed[keysPressed.Count - 1] == KeyCode.S)
            {
                characterRigidbody.velocity = -transform.up * speed;
            }

            if (keysPressed[keysPressed.Count - 1] == KeyCode.D)
            {
                characterRigidbody.velocity = transform.right * speed;
            }
        }
        // IF THE LIST IS EMPTY, STOP THE CHARACTER MOVING
        else
        {
            characterRigidbody.velocity = Vector2.zero;
        }

        //// PRINT THE CONTENTS OF THE LIST FOR DEBUGGING
        //string listContents = "";

        //for (int i = 0; i < keysPressed.Count; i++)
        //{
        //    listContents = listContents + keysPressed[i];
        //}

        //Debug.Log(listContents);
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


