
using UnityEngine;
using System.Timers;
using System;

public class Movement : MonoBehaviour
{
    public GameObject bombPrefab;

    private Vector3 startPosition; // keep track of your initial position as well as your desired position
    private Vector3 desiredPos; // keep track of your desired position after pressing a movement button

    public float movementDistance;

    float lerpTime = 1f;
    float currentLerpTime;

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
        startPosition = transform.position; // Keep track of the object's original position

        if (Input.GetKey("w"))
        {
            desiredPos = new Vector3(startPosition.x, startPosition.y += movementDistance, startPosition.z); // move up
        }

        if (Input.GetKey("a"))
        {
            desiredPos = new Vector3(startPosition.x -= movementDistance, startPosition.y, startPosition.z); // move left
        }

        if (Input.GetKey("s"))
        {
            desiredPos = new Vector3(startPosition.x, startPosition.y -= movementDistance, startPosition.z); // move down
        }

        if (Input.GetKey("d"))
        {
            desiredPos = new Vector3(startPosition.x += movementDistance, startPosition.y, startPosition.z); // move right
        }

        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(startPosition, desiredPos, perc);
    }


    void placeBombs()
    {
        var pos = transform.position;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bombPrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        }
    }

}
