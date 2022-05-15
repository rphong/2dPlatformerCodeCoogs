using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trap;
    public int difficulty = 1;

    public void spawnTrap()
    {
        GameObject childTrap = (GameObject)Instantiate(trap, transform.position, transform.rotation);
        childTrap.transform.parent = transform;
    }

}
