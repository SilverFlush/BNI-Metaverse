using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenDelay : MonoBehaviour
{
    [Header("Load Scene")]
    public string TargetScene;
    public float Delay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InvokeLoadScene", Delay);
    }

    void InvokeLoadScene()
    {
        SceneManager.LoadScene(TargetScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
