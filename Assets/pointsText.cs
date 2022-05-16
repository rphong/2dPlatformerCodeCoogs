using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pointsText : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Update is called once per frame
    void Update()
    {
        score.text = "Points:    " + GameStats.totalPoints.ToString();
    }
}
