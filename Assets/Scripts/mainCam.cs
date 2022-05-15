using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void Start()
    {
        player = GameObject.Find("mainChar(Clone)");
    }

    void Update()
    {
        if(player != null)
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }

}
