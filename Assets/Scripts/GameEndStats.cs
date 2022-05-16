using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndStats : MonoBehaviour
{
    public TextMeshProUGUI totalPointTxt;
    public TextMeshProUGUI levelReachedTxt;
    public TextMeshProUGUI timeLivedTxt;
    public TextMeshProUGUI avgTimePerLevelTxt;
    public int CountFPS = 30;
    public float Duration = 1f;
    public string NumberFormat = "N0";

    private void Awake()
    {
        StartCoroutine(UpdateText());
    }

    private IEnumerator UpdateText()
    {

        yield return StartCoroutine(CountText(GameStats.totalPoints, totalPointTxt));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(CountText(GameStats.levelReached, levelReachedTxt));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(CountText(GameStats.timeLived, timeLivedTxt));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(CountText(GameStats.timePerLevel, avgTimePerLevelTxt));
    }

    private IEnumerator CountText(int newValue, TextMeshProUGUI Text)
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
        int previousValue = 0;
        int stepAmount;

        if (newValue - previousValue < 0)
        {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = -20, previousValue = 0. CountFPS = 30, and Duration = 1; (-20- 0) / (30*1) // -0.66667 (ceiltoint)-> 0
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = 20, previousValue = 0. CountFPS = 30, and Duration = 1; (20- 0) / (30*1) // 0.66667 (floortoint)-> 0
        }

        if (previousValue < newValue)
        {
            while (previousValue < newValue)
            {
                previousValue += stepAmount;
                if (previousValue > newValue)
                {
                    previousValue = newValue;
                }

                Text.SetText(previousValue.ToString(NumberFormat));

                yield return Wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount; // (-20 - 0) / (30 * 1) = -0.66667 -> -1              0 + -1 = -1
                if (previousValue < newValue)
                {
                    previousValue = newValue;
                }

                Text.SetText(previousValue.ToString(NumberFormat));

                yield return Wait;
            }
        }
    }


}
