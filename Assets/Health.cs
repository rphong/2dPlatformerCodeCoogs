using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private int startingHealth;
    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;    
    }

    public void takeDamage(int dam)
    {
        currentHealth = Mathf.Clamp(currentHealth - dam, 0, startingHealth);
        if(currentHealth > 0) //Take damage
        {

        }
        else //Die
        {

        }
    }
    private IEnumerable Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(3, 10, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }
}
