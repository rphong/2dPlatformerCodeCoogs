using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private void Awake()
    {
        GameStats.gameDifficulty = 1;
        Debug.Log("Hi diff set");
    }

}
