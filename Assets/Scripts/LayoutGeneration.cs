using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;
    public GameObject mainCam;
    public GameObject healthUI;

    public GameObject player;
    public frogMovement playerScript;
    public GameObject entryPortal;
    public EntryPortal entryPortalScript;
    public GameObject exitPortal;

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

    public int currentDifficulty;

    public float minX, maxX, minY;
    public LayerMask room;
    public LayerMask spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentDifficulty = GameStats.gameDifficulty;
        Physics2D.IgnoreLayerCollision(3, 10, false);

        int randStartPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartPos].position;
        Instantiate(rooms[4], transform.position, Quaternion.identity);
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
            Collider2D roomSpawnPoint = Physics2D.OverlapCircle(transform.position, 1, spawnPoints);
            if (roomSpawnPoint != null)
                roomSpawnPoint.GetComponent<SpawnRoom>().destroySpawnPoint();
            spawnRoom();
            currSpawnTime = 0;
        }
        else
        {
            currSpawnTime += Time.deltaTime;
        }
        if(!charSpawned && roomCount == 16)
        {
            var startPosCam = startPos;
            startPosCam.z = -10;
            Instantiate(mainCam, startPosCam, Quaternion.identity);
            StartCoroutine(openingPortalAnim());

            AudioListener tempAudio = GameObject.Find("AudioManager").GetComponent<AudioListener>();
            if(tempAudio != null) Destroy(tempAudio.GetComponent<AudioListener>());

            FindObjectOfType<AudioManager>().Play("Theme");
            charSpawned = true;
        }

        if(Input.GetKeyDown("r"))
        {
            player.transform.position = startPos;
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

                Vector3 newRoomPos = new Vector3(transform.position.x + roomDist, transform.position.y, transform.position.z);
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

                Vector3 newRoomPos = new Vector3(transform.position.x - roomDist, transform.position.y, transform.position.z);
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
            Instantiate(exitPortal, transform.position, Quaternion.identity);
            Collider2D roomSpawnPoint = Physics2D.OverlapCircle(transform.position, 1, spawnPoints);
            if (roomSpawnPoint != null)
                roomSpawnPoint.GetComponent<SpawnRoom>().destroySpawnPoint();
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

        Vector3 newRoomPos = new Vector3(transform.position.x, transform.position.y - roomDist, transform.position.z);
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

    private IEnumerator openingPortalAnim()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(entryPortal, startPos, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        Instantiate(player, startPos, Quaternion.identity);

        entryPortalScript = GameObject.Find("EntryPortal(Clone)").GetComponent<EntryPortal>();
        player = GameObject.Find("mainChar(Clone)");
        playerScript = player.GetComponent<frogMovement>();

        playerScript.applyForceX(-1f);
        healthUI.SetActive(true);


        yield return new WaitForSeconds(2f);
        entryPortalScript.closePortal();
    }

}
