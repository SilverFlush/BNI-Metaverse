using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;  

public class TokenReader : MonoBehaviour
{
    [Header("Token Settings")]
    public Text Token;

    [Header("Event Settings")]
    public UnityEvent TokenEvents;

    // Start is called before the first frame update
    void Start()
    {
        this.ListHREFParameters();
    }

    void ListHREFParameters()
    {
        Dictionary<string, string> prms = ParamParse.GetBrowserParameters();

        foreach (KeyValuePair<string, string> kvp in prms)
        {
            if (string.IsNullOrEmpty(kvp.Value) == true)
            {
                Token.text = "Empty Token";
            }
            else
            {
                if (kvp.Key == "q")
                {
                    Token.text = kvp.Value;
                    PlayerPrefs.SetString("TOKEN", Token.text);
                    TokenEvents.Invoke();
                }
            }
        }
    }
}
