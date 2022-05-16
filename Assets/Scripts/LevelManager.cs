using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject layoutGenObj;
    public LayoutGeneration layoutGen;

    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;

    private float target;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        layoutGenObj = GameObject.Find("LayoutGenerator");
        layoutGen = layoutGenObj.GetComponent<LayoutGeneration>();
        loadScene();
    }

    
    public async void loadScene()
    {
        loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(300);
            target = Mathf.Max(layoutGen.roomCount/16, .1f);
        } while (layoutGen.roomCount < 16);
        await Task.Delay(1000);

        loaderCanvas.SetActive(false);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, Time.deltaTime);
    }
}
