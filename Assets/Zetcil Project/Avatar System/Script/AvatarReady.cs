using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarReady : MonoBehaviour
{

    [Header("Male Hair")]
    public List<GameObject> MHair;

    [Header("Male Shirt")]
    public List<GameObject> MShirt;

    [Header("Male Pant")]
    public List<GameObject> MPant;

    [Header("Male Shoe")]
    public List<GameObject> MShoe;

    [Header("Female Hair")]
    public List<GameObject> FHair;

    [Header("Female Shirt")]
    public List<GameObject> FShirt;

    [Header("Female Pant")]
    public List<GameObject> FPant;

    [Header("Female Shoe")]
    public List<GameObject> FShoe;

    //-- Set Hair M
    public void HideHairM()
    {
        for (int i = 0; i < MHair.Count; i++)
        {
            MHair[i].SetActive(false);
        }
    }

    public void SetHairM()
    {
        HideHairM();
        int Index = PlayerPrefs.GetInt("STEP3-HAIR");
        MHair[Index].SetActive(true);
        Debug.Log("GET-HAIR:" + Index.ToString());
    }

    //-- Set Shirt M
    public void HideShirtM()
    {
        for (int i = 0; i < MShirt.Count; i++)
        {
            MShirt[i].SetActive(false);
        }
    }

    public void SetShirtM()
    {
        HideShirtM();
        int Index = PlayerPrefs.GetInt("STEP3-SHIRT");
        MShirt[Index].SetActive(true);
        Debug.Log("GET-SHIRT:" + Index.ToString());
    }

    //-- Set Pant M
    public void HidePantM()
    {
        for (int i = 0; i < MPant.Count; i++)
        {
            MPant[i].SetActive(false);
        }
    }

    public void SetPantM()
    {
        HidePantM();
        int Index = PlayerPrefs.GetInt("STEP3-PANT");
        MPant[Index].SetActive(true);
        Debug.Log("GET-PANT:" + Index.ToString());
    }

    //-- Set Shoe M
    public void HideShoeM()
    {
        for (int i = 0; i < MShoe.Count; i++)
        {
            MShoe[i].SetActive(false);
        }
    }

    public void SetShoeM()
    {
        HideShoeM();
        int Index = PlayerPrefs.GetInt("STEP3-SHOE");
        MShoe[Index].SetActive(true);
        Debug.Log("GET-SHOE:" + Index.ToString());
    }


    //******************************************************************************** Set Hair F
    public void HideHairF()
    {
        for (int i = 0; i < FHair.Count; i++)
        {
            FHair[i].SetActive(false);
        }
    }

    public void SetHairF()
    {
        HideHairF();
        int Index = PlayerPrefs.GetInt("STEP3-HAIR");
        FHair[Index].SetActive(true);
        Debug.Log("GET-HAIR:" + Index.ToString());
    }

    //-- Set Shirt F
    public void HideShirtF()
    {
        for (int i = 0; i < FShirt.Count; i++)
        {
            FShirt[i].SetActive(false);
        }
    }

    public void SetShirtF()
    {
        HideShirtF();
        int Index = PlayerPrefs.GetInt("STEP3-SHIRT");
        FShirt[Index].SetActive(true);
        Debug.Log("GET-SHIRT:" + Index.ToString());
    }

    //-- Set Pant F
    public void HidePantF()
    {
        for (int i = 0; i < FPant.Count; i++)
        {
            FPant[i].SetActive(false);
        }
    }

    public void SetPantF()
    {
        HidePantF();
        int Index = PlayerPrefs.GetInt("STEP3-PANT");
        FPant[Index].SetActive(true);
        Debug.Log("GET-PANT:" + Index.ToString());
    }

    //-- Set Shoe F
    public void HideShoeF()
    {
        for (int i = 0; i < FShoe.Count; i++)
        {
            FShoe[i].SetActive(false);
        }
    }

    public void SetShoeF()
    {
        HideShoeF();
        int Index = PlayerPrefs.GetInt("STEP3-SHOE");
        FShoe[Index].SetActive(true);
        Debug.Log("GET-SHOE:" + Index.ToString());
    }


    // Start is called before the first frame update
    void Start()
    {
        SetHairM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
