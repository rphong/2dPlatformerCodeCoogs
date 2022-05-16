using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPortal : MonoBehaviour
{
    Animator portalAnimator;
    private void Awake()
    {
        portalAnimator = GetComponent<Animator>();
    }

    public void closePortal()
    {
        StartCoroutine(closeAndDissapear());
    }

    private IEnumerator closeAndDissapear()
    {
        portalAnimator.Play("EntryPortalClose");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
