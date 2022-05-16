using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void switchScene(string name)
    {
        FindObjectOfType<AudioManager>().StopPlaying("Theme");

        SceneManager.LoadScene(name);

        if (name == "MainLevel")
        {
            Debug.Log("diff inc");
            GameStats.gameDifficulty++;
            GameStats.totalPoints += 100 + 50 * GameStats.gameDifficulty;
        }
    }
}
