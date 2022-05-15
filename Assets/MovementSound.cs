using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip FrogFootStep1;

    [SerializeField]
    private AudioClip FrogFootStep2;

    [SerializeField]
    private AudioClip FrogFootStep3;

    [SerializeField]
    private AudioClip FrogFootStep4;

    [SerializeField]
    private AudioClip[] FrogFootStepArray;

    public void RandomFrogFootStepsFunction()
    {
        int randomType = UnityEngine.Random.Range(0, 3);
        AudioSource.PlayClipAtPoint(FrogFootStepArray[randomType], transform.position);
    }


    public void frogfootstepfunction1()
    {
        AudioSource.PlayClipAtPoint(FrogFootStep1, transform.position);
    }

    public void frogfootstepfunction2()
    {
        AudioSource.PlayClipAtPoint(FrogFootStep2, transform.position);
    }

    public void frogfootstepfunction3()
    {
        AudioSource.PlayClipAtPoint(FrogFootStep3, transform.position);
    }

    public void frogfootstepfunction4()
    {
        AudioSource.PlayClipAtPoint(FrogFootStep4, transform.position);
    }
}
