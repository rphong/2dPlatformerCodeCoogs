using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    private Animator _animator;

    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;   
        _animator = GetComponent<Animator>();

    }

    public void takeDamage(int dam)
    {
        //If already hurt, invincibility frame
        if (_animator.GetBool("Hurt") == true) return;

        currentHealth = Mathf.Clamp(currentHealth - dam, 0, startingHealth);

        //if hurt, play "Damage" sound effect
        FindObjectOfType<AudioManager>().Play("Damage");

        if (currentHealth > 0) //Take damage
        {
            Debug.Log("Current health: " + currentHealth);
            StartCoroutine(Invulnerability());
        }
        else //Die
        {
            Debug.Log("Dead");
        }
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(3, 10, true);
        _animator.SetBool("Hurt", true);
        _animator.Play("Hurt");
        yield return new WaitForSeconds(1f);

        _animator.SetBool("Hurt", false);
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }
}
