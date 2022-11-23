using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerSystem : MonoBehaviour
{
    [Header("Server")]
    [TextArea(3, 4)]
    public string URL = "http://localhost/coder/api";
    public bool InitializeServer;

    public void SetServerData(Text txtURL)
    {
        PlayerPrefs.SetString(AuthConstant.CURRENT_SERVER, txtURL.text);
        Debug.Log("Server set to: "+ txtURL.text);
    }

    public void SetServerData()
    {
        PlayerPrefs.SetString(AuthConstant.CURRENT_SERVER, URL);
        Debug.Log("Server set to: " + URL);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey(AuthConstant.CURRENT_SERVER) || InitializeServer)
        {
            SetServerData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
