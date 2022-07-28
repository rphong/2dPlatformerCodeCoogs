using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;
    public Image totalHealth;
    public Image currentHealth;

    private void Start()
    {
        //Set initial health
        totalHealth.fillAmount = (float)GameStats.maxGameHealth / 10;
    }

    private void instantiateHealthUI()
    {
        playerHealth = GameObject.Find("mainChar(Clone)").GetComponent<Health>();
    }

    void Update()
    {
        if (playerHealth == null) instantiateHealthUI();
        currentHealth.fillAmount = playerHealth.currentHealth / 10;
    }
}
