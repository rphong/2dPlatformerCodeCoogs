using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void switchScene(string name)
    {
        //Remove music when switching scenes
        FindObjectOfType<AudioManager>().StopPlaying("Theme");

        SceneManager.LoadScene(name);

        if (name == "MainLevel")
        {
            //When loading new level, increase difficulty & add points
            GameStats.gameDifficulty++;
            GameStats.totalPoints += 100 + 50 * GameStats.gameDifficulty;
        }
    }
}
