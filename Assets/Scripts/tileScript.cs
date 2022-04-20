using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public bool isBreakable = false;
    public void destroyTile()
    {
        Destroy(gameObject);
    }
}
