using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    Animator portalAnimator;
    changeScene newScene;
    private void Awake()
    {
        portalAnimator = GetComponent<Animator>();
        newScene = GetComponent<changeScene>();
        portalAnimator.Play("ExitPortalOpen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameStats.gameDifficulty++;
            StartCoroutine(closeAndDissapear());
        }
    }

    private IEnumerator closeAndDissapear()
    {
        portalAnimator.Play("ExitPortalClose");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        newScene.switchScene("MainLevel");

    }
}
