using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;
    public Image totalHealth;
    public Image currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log((float)GameStats.maxGameHealth);
        totalHealth.fillAmount = (float)GameStats.maxGameHealth / 10;
    }

    private void instantiateHealthUI()
    {
        playerHealth = GameObject.Find("mainChar(Clone)").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == null) instantiateHealthUI();
        currentHealth.fillAmount = playerHealth.currentHealth / 10;
    }
}
