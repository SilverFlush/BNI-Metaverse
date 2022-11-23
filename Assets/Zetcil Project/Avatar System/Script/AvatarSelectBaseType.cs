using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectBaseType : MonoBehaviour
{

    [Header("Main Settings")]
    public int BaseAvatarIndex;

    [Header("Image Settings")]
    public Image TargetImage;

    [Header("Image Settings")]
    public Image TargetImageM;
    public Image TargetImageF;

    [Header("Gender Type")]
    public GameObject AvatarM;
    public GameObject AvatarF;

    bool isMasculine;

    public void SetBaseAvatarIndex(int aIndex)
    {
        BaseAvatarIndex = aIndex;
        PlayerPrefs.SetInt("STEP2", BaseAvatarIndex);
    }

    public void SetBaseAvatarImage(Image ToggleImage)
    {
        TargetImage.sprite = ToggleImage.sprite;
    }

    public void InitAvatarSelectBaseType()
    {
        AvatarM.SetActive(false);
        AvatarF.SetActive(false);
        isMasculine = PlayerPrefs.GetString("STEP1") == "MASCULINE";
        Debug.Log("GET:"+PlayerPrefs.GetString("STEP1"));
        if (isMasculine)
        {
            TargetImage = TargetImageM;
            AvatarM.SetActive(true);
        }
        else
        {
            TargetImage = TargetImageF;
            AvatarF.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitAvatarSelectBaseType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
