using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;
    public GameObject player;
    public GameObject mainCam;

    private int direction;
    private int downCount = 0;
    public int roomDist;

    private float currSpawnTime = 0;
    public float roomSpawnInterval = 0.01f;
    public bool stopRoomSpawn = false;
    public bool spawnTiles = false;
    public int roomCount = 0;

    private Vector3 startPos;
    private bool charSpawned = false;

    public float minX, maxX, minY;
    public LayerMask room;
    // Start is called before the first frame update
    void Start()
    {
        int randStartPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartPos].position;
        Instantiate(rooms[3], transform.position, Quaternion.identity);
        startPos = transform.position;
        startPos.y += 1;

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
        if(!charSpawned && roomCount == 16)
        {
            Instantiate(player, startPos, Quaternion.identity);
            Instantiate(mainCam, startPos, Quaternion.identity);
            charSpawned = true;
        }
    }
    private void spawnRoom()
    {
        if (direction == 1 || direction == 2)//Move right
        {
            if (transform.position.x >= maxX) //If reached right edge, go down
            {
                goDown();
            }
            else
            {
                downCount = 0;
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<Room>().roomType == 0)
                {
                    roomDetection.GetComponent<Room>().deleteRoom();

                    Instantiate(rooms[Random.Range(2, 4)], transform.position, Quaternion.identity);
                }

                Vector2 newRoomPos = new Vector2(transform.position.x + roomDist, transform.position.y);
                transform.position = newRoomPos;
                goRightOrDown();
                Instantiate(rooms[Random.Range(2, 4)], transform.position, Quaternion.identity);
            }
        }
        else if (direction == 3 || direction == 4)//Move left
        {
            if (transform.position.x <= minX) //If reached left edge, go down
            {
                goDown();
            }
            else
            {
                downCount = 0;
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<Room>().roomType == 0)
                {
                    roomDetection.GetComponent<Room>().deleteRoom();

                    Instantiate(rooms[Random.Range(2,4)], transform.position, Quaternion.identity);
                }

                Vector2 newRoomPos = new Vector2(transform.position.x - roomDist, transform.position.y);
                transform.position = newRoomPos;
                goLeftOrDown();
                Instantiate(rooms[Random.Range(2, 4)], transform.position, Quaternion.identity);
            }
        }
        else if(direction == 5)
        {
            goDown();
        }

        
        if (transform.position.y <= minY)//If reached bottom
        {
            stopRoomSpawn = true;
            spawnTiles = true;
        }
    }

    private void goDown()
    {
        downCount++;
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
        if (roomDetection.GetComponent<Room>().roomType != 0 && roomDetection.GetComponent<Room>().roomType != 1)
        {
            roomDetection.GetComponent<Room>().deleteRoom();

            if (downCount >= 2)
                Instantiate(rooms[0], transform.position, Quaternion.identity);
            else
                Instantiate(rooms[1], transform.position, Quaternion.identity);
        }

        Vector2 newRoomPos = new Vector2(transform.position.x, transform.position.y - roomDist);
        transform.position = newRoomPos;
        direction = Random.Range(1, 6);
        Instantiate(rooms[2], transform.position, Quaternion.identity);
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
