using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth;
    private Animator _animator;
    private GameObject frogChar;
    [SerializeField] private GameObject deathScreen;


    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        startingHealth = GameStats.maxGameHealth;
        currentHealth = GameStats.currentGameHealth;   
        _animator = GetComponent<Animator>();
    }

    public void takeDamage(int dam)
    {
        //If already hurt, invincibility frame
        if (_animator.GetBool("Hurt") == true) return;

        currentHealth = Mathf.Clamp(currentHealth - dam, 0, startingHealth);
        GameStats.currentGameHealth--;

        //if hurt, play "Damage" sound effect
        FindObjectOfType<AudioManager>().Play("Damage");

        if (currentHealth > 0) //Take damage
        {
            Debug.Log("Current health: " + currentHealth);
            StartCoroutine(Invulnerability());
        }
        else //Die
        {
            frogChar = GameObject.Find("mainChar(Clone)");
            frogChar.SetActive(false);
            GameStats.gameEndTime = (int)Mathf.Ceil(Time.time);
            GameStats.timeLived = GameStats.gameEndTime - GameStats.gameStartTime;
            GameStats.timePerLevel = GameStats.timeLived / GameStats.levelReached;
            Instantiate(deathScreen);
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
