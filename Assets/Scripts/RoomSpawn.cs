using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, rooms.Length);
        GameObject childTile = (GameObject)Instantiate(rooms[rand], transform.position, Quaternion.identity);
        childTile.transform.parent = transform;
    }
}
