using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleEvent : MonoBehaviour
{

    public bool isSelect;
    public UnityEvent OnEvent;
    public UnityEvent OffEvent;
    Toggle CurrentToggle;


    // Start is called before the first frame update
    void Start()
    {
        CurrentToggle = GetComponent<Toggle>();
        if (isSelect) CurrentToggle.Select();
    }

    public void CheckToggle()
    {
        if (CurrentToggle.isOn)
        {
            OnEvent.Invoke();
        }
        else if (!CurrentToggle.isOn)
        {
            OffEvent.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
