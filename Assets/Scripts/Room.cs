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
    }
    private void Update()
    {
        if (layoutGen.spawnTiles == true && roomSpawned == false && layoutGen.roomCount == 16)
        {
            
            foreach (Transform child in transform)
            {
                TileSpawn tileScript = child.GetComponent<TileSpawn>();
                tileScript.spawnTile();
            }
            roomSpawned = true;
        }
    }
    public void deleteRoom()
    {
        Destroy(gameObject);
    }
    
}
