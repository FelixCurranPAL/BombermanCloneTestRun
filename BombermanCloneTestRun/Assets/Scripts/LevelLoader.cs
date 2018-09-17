using UnityEngine;
using System;
using System.Collections.Generic; 		
using Random = UnityEngine.Random; 		

public class LevelLoader : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] breakableWallTiles;
    public GameObject player;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>(); //Used to hold all possible positions on game board for spawning things

    public int minColumns = 8; //Number of possible columns in our game board.
    public int maxColumns = 15; 
    public int minRows = 8; //Number of possible rows in our game board.
    public int maxRows = 15; 
    private int columns;
    private int rows;

    public float minWallPercentage = 0.66f; //Lower and upper limit for our random number of destructable walls per level.
    public float maxWallPercentage = 0.90f; 
    private int minWallsToSpawn;
    private int maxWallsToSpawn;

    private Vector3 playerPosition;

    // Use this for initialization
    void Start () {
        //Choose a random amount of columns and rows for our game board (based on the public variables)
        columns = Random.Range(minColumns, maxColumns);
        rows = Random.Range(minRows, maxRows);

        //Instantiate random tiles and walls that make up the board outline and inner floors
        BoardSetup();

        //Make a list of all possible spawn locations within the game board
        InitialiseList();

        //Instantiate the player in the upper right hand corner of our game board
        playerPosition = new Vector3(columns - 1, rows - 1, 0f);
        Instantiate(player, playerPosition, Quaternion.identity);

        // remove potential to spawn anything near player
        gridPositions.Remove(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x, playerPosition.y+1, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x, playerPosition.y-1, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x+1, playerPosition.y, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x+1, playerPosition.y+1, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x+1, playerPosition.y-1, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x-1, playerPosition.y, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x-1, playerPosition.y+1, playerPosition.z));
        gridPositions.Remove(new Vector3(playerPosition.x-1, playerPosition.y-1, playerPosition.z));

        // SPAWN RANDOM UNBREAKABLE WALLS

        //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
        LayoutObjectAtRandom(breakableWallTiles, minWallsToSpawn, maxWallsToSpawn);

        // SPAWN RANDOM ENEMIES

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = -1; x < columns + 1; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = -1; y < rows + 1; y++)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                //Check if the current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];

                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();

        //Loop through x axis (columns).
        for (int x = 0; x < columns; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 0; y < rows; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }

        // figure out total amount of potential walls to spawn based on total possible spawn locations and percentages provided by public variables
        minWallsToSpawn = Mathf.RoundToInt(minWallPercentage * gridPositions.Count);
        maxWallsToSpawn = Mathf.RoundToInt(maxWallPercentage * gridPositions.Count);
    }

    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, gridPositions.Count);

        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = gridPositions[randomIndex];

        //Remove the entry at randomIndex from the list so that it can't be re-used.
        gridPositions.RemoveAt(randomIndex);

        //Return the randomly selected Vector3 position.
        return randomPosition;
    }

    //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

}
