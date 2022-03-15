using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tiles;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, tiles.Length);
        Instantiate(tiles[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
}
