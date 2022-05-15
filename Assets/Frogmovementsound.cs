using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogmovementsound : MonoBehaviour
{
    [SerializeField]
    private AudioClip Footstep1;

    [SerializeField]
    private AudioClip Footstep2;

    [SerializeField]
    private AudioClip Footstep3;

    [SerializeField]
    private AudioClip Footstep4;

    [SerializeField]
    private AudioClip[] FootstepArray;

    public void RandomFroggieStepsFunction()
    {
        int randomType = UnityEngine.Random.Range(0, 3);
        AudioSource.PlayClipAtPoint(FootstepArray[randomType], transform.position);
    }

    public void froggiefootstepfunction1()
    {
        AudioSource.PlayClipAtPoint(Footstep1, transform.position);
    }

    public void froggiefootstepfunction2()
    {
        AudioSource.PlayClipAtPoint(Footstep2, transform.position);
    }

    public void froggiefootstepfunction3()
    {
        AudioSource.PlayClipAtPoint(Footstep3, transform.position);
    }

    public void froggiefootstepfunction4()
    {
        AudioSource.PlayClipAtPoint(Footstep4, transform.position);
    }


}
