using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelectBodyPart : MonoBehaviour
{

    [Header("Male Body Part")]
    public GameObject MHeadPanel;
    public GameObject MShirtPanel;
    public GameObject MPantPanel;
    public GameObject MShoePanel;

    [Header("Male Hair")]
    public List<GameObject> MHair;

    [Header("Male Shirt")]
    public List<GameObject> MShirt;

    [Header("Male Pant")]
    public List<GameObject> MPant;

    [Header("Male Shoe")]
    public List<GameObject> MShoe;

    [Header("Female Body Part")]
    public GameObject FHeadPanel;
    public GameObject FShirtPanel;
    public GameObject FPantPanel;
    public GameObject FShoePanel;

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

    public void SetHairM(int aIndex)
    {
        HideHairM();
        MHair[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-HAIR", aIndex);
        Debug.Log("SET-HAIR:" + PlayerPrefs.GetInt("STEP3-HAIR").ToString());
    }

    //-- Set Shirt M
    public void HideShirtM()
    {
        for (int i = 0; i < MShirt.Count; i++)
        {
            MShirt[i].SetActive(false);
        }
    }

    public void SetShirtM(int aIndex)
    {
        HideShirtM();
        MShirt[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-SHIRT", aIndex);
        Debug.Log("SET-SHIRT:" + PlayerPrefs.GetInt("STEP3-SHIRT").ToString());
    }

    //-- Set Pant M
    public void HidePantM()
    {
        for (int i = 0; i < MPant.Count; i++)
        {
            MPant[i].SetActive(false);
        }
    }

    public void SetPantM(int aIndex)
    {
        HidePantM();
        MPant[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-PANT", aIndex);
        Debug.Log("SET-PANT:" + PlayerPrefs.GetInt("STEP3-PANT").ToString());
    }

    //-- Set Shoe M
    public void HideShoeM()
    {
        for (int i = 0; i < MShoe.Count; i++)
        {
            MShoe[i].SetActive(false);
        }
    }

    public void SetShoeM(int aIndex)
    {
        HideShoeM();
        MShoe[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-SHOE", aIndex);
        Debug.Log("SET-SHOE:" + PlayerPrefs.GetInt("STEP3-SHOE").ToString());
    }

    //-- Set Panel M
    public void HidePanelM()
    {
        MHeadPanel.SetActive(false);
        MShirtPanel.SetActive(false);
        MPantPanel.SetActive(false);
        MShoePanel.SetActive(false);
    }

    public void SetHeadPanelM()
    {
        HidePanelM();
        MHeadPanel.SetActive(true);
    }

    public void SetShirtPanelM()
    {
        HidePanelM();
        MShirtPanel.SetActive(true);
    }

    public void SetPantPanelM()
    {
        HidePanelM();
        MPantPanel.SetActive(true);
    }

    public void SetShoePanelM()
    {
        HidePanelM();
        MShoePanel.SetActive(true);
    }

    //**************************************************************************************************** Set Panel F

    //-- Set Hair F
    public void HideHairF()
    {
        for (int i = 0; i < FHair.Count; i++)
        {
            FHair[i].SetActive(false);
        }
    }

    public void SetHairF(int aIndex)
    {
        HideHairF();
        FHair[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-HAIR", aIndex);
        Debug.Log("SET-HAIR:" + PlayerPrefs.GetInt("STEP3-HAIR").ToString());
    }

    //-- Set Shirt F
    public void HideShirtF()
    {
        for (int i = 0; i < FShirt.Count; i++)
        {
            FShirt[i].SetActive(false);
        }
    }

    public void SetShirtF(int aIndex)
    {
        HideShirtF();
        FShirt[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-SHIRT", aIndex);
        Debug.Log("SET-SHIRT:" + PlayerPrefs.GetInt("STEP3-SHIRT").ToString());
    }

    //-- Set Pant F
    public void HidePantF()
    {
        for (int i = 0; i < FPant.Count; i++)
        {
            FPant[i].SetActive(false);
        }
    }

    public void SetPantF(int aIndex)
    {
        HidePantF();
        FPant[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-PANT", aIndex);
        Debug.Log("SET-PANT:" + PlayerPrefs.GetInt("STEP3-PANT").ToString());
    }

    //-- Set Shoe F
    public void HideShoeF()
    {
        for (int i = 0; i < FShoe.Count; i++)
        {
            FShoe[i].SetActive(false);
        }
    }

    public void SetShoeF(int aIndex)
    {
        HideShoeF();
        FShoe[aIndex].SetActive(true);
        PlayerPrefs.SetInt("STEP3-SHOE", aIndex);
        Debug.Log("SET-SHOE:" + PlayerPrefs.GetInt("STEP3-SHOE").ToString());
    }

    public void HidePanelF()
    {
        FHeadPanel.SetActive(false);
        FShirtPanel.SetActive(false);
        FPantPanel.SetActive(false);
        FShoePanel.SetActive(false);
    }

    public void SetHeadPanelF()
    {
        HidePanelF();
        FHeadPanel.SetActive(true);
    }

    public void SetShirtPanelF()
    {
        HidePanelF();
        FShirtPanel.SetActive(true);
    }

    public void SetPantPanelF()
    {
        HidePanelF();
        FPantPanel.SetActive(true);
    }

    public void SetShoePanelF()
    {
        HidePanelF();
        FShoePanel.SetActive(true);
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
