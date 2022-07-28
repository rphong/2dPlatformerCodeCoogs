using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int roomType;
    public bool roomSpawned = false;
    public GameObject layoutGenObj;
    public LayoutGeneration layoutGen;

    private void Start()
    {
        layoutGenObj = GameObject.Find("LayoutGenerator");
        layoutGen = layoutGenObj.GetComponent<LayoutGeneration>();
        layoutGen.roomCount++;
    }
    private void Update()
    {
        if (layoutGen.spawnTiles == true && roomSpawned == false && layoutGen.roomCount == 16)
        {
            //When rooms are finished spawning, spawn tiles and traps
            foreach (Transform child in transform)
            {
                TileSpawn tileScript = child.GetComponent<TileSpawn>();
                if(tileScript != null) tileScript.spawnTile();

                TrapSpawner trapScript = child.GetComponent<TrapSpawner>();
                if (trapScript != null)
                {
                    if (trapScript.difficulty <= layoutGen.currentDifficulty)
                        trapScript.spawnTrap();
                }

            }
            roomSpawned = true;
        }
    }
    public void deleteRoom()
    {
        layoutGen.roomCount--;
        Destroy(gameObject);
    }
    
}
