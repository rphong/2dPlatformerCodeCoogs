using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LayoutGeneration layoutGen;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (roomDetection == null && layoutGen.stopRoomSpawn == true)
        {
            // Spawn Random Room!
            int rand = Random.Range(0, 4);
            Instantiate(layoutGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void destroySpawnPoint()
    {
        Destroy(gameObject);
    }
}
