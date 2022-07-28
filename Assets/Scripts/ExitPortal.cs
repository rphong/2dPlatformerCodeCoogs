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
            StartCoroutine(closeAndDissapear());
        }
    }

    private IEnumerator closeAndDissapear()
    {
        //Start closing portal, add a delay, and then remove from scene
        portalAnimator.Play("ExitPortalClose");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

        //Load into new level
        newScene.switchScene("MainLevel");
    }
}
