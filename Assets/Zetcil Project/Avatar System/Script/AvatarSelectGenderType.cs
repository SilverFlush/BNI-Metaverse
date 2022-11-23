using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelectGenderType : MonoBehaviour
{

    [Header("Main Settings")]
    public bool Masculine;
    public bool Feminine;

    public void SetMasculine()
    {
        Masculine = true; 
        Feminine = false; 
        PlayerPrefs.SetString("STEP1", "MASCULINE");
        Debug.Log("SET:MASCULINE");
    }

    public void SetFeminine()
    {
        Masculine = false;
        Feminine = true;
        PlayerPrefs.SetString("STEP1", "FEMININE");
        Debug.Log("SET:FEMININE");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
