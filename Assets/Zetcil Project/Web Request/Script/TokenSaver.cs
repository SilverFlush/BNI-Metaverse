using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSaver : MonoBehaviour
{

    [Header("Token Settings")]
    public string Token;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("TOKEN", Token);
        Debug.Log("TOKEN:"+ Token);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
