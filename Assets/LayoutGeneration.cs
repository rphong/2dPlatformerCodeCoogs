using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;

    private int direction;
    public int roomDist;

    private float currSpawnTime = 0;
    public float roomSpawnInterval = 0.25f;
    private bool stopRoomSpawn = false;

    public float minX, maxX, minY;
    // Start is called before the first frame update
    void Start()
    {
        int randStartPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
        if (transform.position.x <= minX)//If started left border, go right or down
        {
            goRightOrDown();
        }

        else if (transform.position.x >= maxX)//If started right border, go left or down
        {
            goLeftOrDown();
        }
    }

    private void Update()
    {
        if (currSpawnTime >= roomSpawnInterval && stopRoomSpawn == false)
        {
            spawnRoom();
            currSpawnTime = 0;
        }
        else
        {
            currSpawnTime += Time.deltaTime;
        }
    }

    private void spawnRoom()
    {
        if (direction == 1 || direction == 2)//Move right
        {
            Vector2 newRoomPos = new Vector2(transform.position.x + roomDist, transform.position.y);
            transform.position = newRoomPos;
            goRightOrDown();
        }
        else if (direction == 3 || direction == 4)//Move left
        {
            Vector2 newRoomPos = new Vector2(transform.position.x - roomDist, transform.position.y);
            transform.position = newRoomPos;
            goLeftOrDown();
        }
        else
        {
            Vector2 newRoomPos = new Vector2(transform.position.x, transform.position.y - roomDist);
            transform.position = newRoomPos;
            direction = Random.Range(1, 6);
        }

        Instantiate(rooms[0], transform.position, Quaternion.identity);

        if (transform.position.y <= minY)//If reached bottom
            stopRoomSpawn = true;

        else if (transform.position.x <= minX || transform.position.x >= maxX) //If reached right/left edge, go down
        {
            direction = 5;
        }
    }

    private void goLeftOrDown()
    {
        direction = Random.Range(1, 6);
        while (direction == 1 || direction == 2)
        {
            direction = Random.Range(1, 6);
        }
    }

    private void goRightOrDown()
    {
        direction = Random.Range(1, 6);
        while (direction == 3 || direction == 4)
        {
            direction = Random.Range(1, 6);
        }
    }
}
