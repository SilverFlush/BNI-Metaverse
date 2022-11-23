using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemGetColor : MonoBehaviour
{

    [Header("Color System")]
    public List<Image> UIImage;
    public List<Text> UIText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < UIImage.Count; i++)
        {
            Color color = Color.black;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("AuthColor"), out color);
            UIImage[i].color = color;
        }
        for (int i = 0; i < UIText.Count; i++)
        {
            Color color = Color.black;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("AuthColor"), out color);
            UIText[i].color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
