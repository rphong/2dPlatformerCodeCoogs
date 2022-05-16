using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private void Awake()
    {
        GameStats.gameDifficulty = 10;
        GameStats.maxGameHealth = 3;
        GameStats.totalPoints = 100;
        GameStats.timeLived = 1000;
        GameStats.timePerLevel = 100;
        GameStats.currentGameHealth = GameStats.maxGameHealth;
    }

    public void recordStart()
    {
        GameStats.gameStartTime = (int)Mathf.Ceil(Time.time);
    }

    public void closeGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

}
