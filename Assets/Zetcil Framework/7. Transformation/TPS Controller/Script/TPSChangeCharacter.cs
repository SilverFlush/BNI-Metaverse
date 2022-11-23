using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSChangeCharacter : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject AvatarParent;
    public GameObject AvatarOrigin;
    public GameObject AvatarSwitch;
    public Animator AvatarAnimator;

    public void SwitchCharacter()
    {
        AvatarSwitch.transform.parent = AvatarParent.transform;
        AvatarSwitch.transform.position = AvatarOrigin.transform.position;
        AvatarOrigin.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
