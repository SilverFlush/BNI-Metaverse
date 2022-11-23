using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateAvatar : MonoBehaviour
{
    [System.Serializable]
    public class CAvatar
    {
        public Toggle Toggle;
        public GameObject Prefab;
        public Sprite AvatarImage;
    }

    [Header("Main Container")]
    public GameObject TargetPlane;
    public Image TargetImage;

    [Header("Main Position")]
    public GameObject TargetClone;

    [Header("Group Collection")]
    public GameObject Male;
    public GameObject Female;

    [Header("Avatar Collection")]
    public List<CAvatar> AvatarM;
    public List<CAvatar> AvatarF;

    [Header("Avatar GameObject")]
    public GameObject TargetAvatar;

    public void PrepareImage()
    {
        if (Male.active)
        {
            for (int i = 0; i < AvatarM.Count; i++)
            {
                if (AvatarM[i].Toggle.isOn)
                {
                    TargetImage.sprite = AvatarM[i].AvatarImage;
                }
            }
        }
        else if (Female.active)
        {
            for (int i = 0; i < AvatarF.Count; i++)
            {
                if (AvatarF[i].Toggle.isOn)
                {

                }
            }
        }
    }

    public void PrepareCustomization()
    {
        if (TargetAvatar != null)
        {
            Destroy(TargetAvatar);
        }

        if (Male.active)
        {
            for (int i = 0; i < AvatarM.Count; i++)
            {
                if (AvatarM[i].Toggle.isOn)
                {
                    TargetAvatar = Instantiate(AvatarM[i].Prefab, Vector3.zero, Quaternion.identity, TargetPlane.transform);
                    TargetAvatar.transform.position = TargetClone.transform.position;
                    TargetAvatar.transform.rotation = TargetClone.transform.rotation;
                    TargetAvatar.transform.localScale = TargetClone.transform.localScale;
                    TargetImage.sprite = AvatarM[i].AvatarImage;
                }
            }
        }
        else if (Female.active)
        {
            for (int i = 0; i < AvatarF.Count; i++)
            {
                if (AvatarF[i].Toggle.isOn)
                {

                }
            }
        }
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

