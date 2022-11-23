using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSetColor : MonoBehaviour
{
    [Header("Color System")]
    public Color MainColor;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetString("AuthColor", "#"+ColorUtility.ToHtmlStringRGBA(MainColor));
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
