using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class LoginSystem : MonoBehaviour
{
    [Header("Server")]
    [TextArea(3, 4)]
    public string URL = "http://localhost/coder/api/post";
    public string Segment;

    [Header("Data")]
    public InputField Email;
    public InputField Password;

    [Header("Events")]
    public UnityEvent LoginSuccessEvent;
    public UnityEvent LoginFailureEvent;
    public UnityEvent UnknownEvent;

    [Header("System")]
    public string CurrentUser;
    public string CurrentPass;

    string RequestStatus = "";
    bool email_focused;
    bool pass_focused;

    public void GetDataSystem()
    {
        URL = PlayerPrefs.GetString(AuthConstant.CURRENT_SERVER);
        CurrentUser = PlayerPrefs.GetString(AuthConstant.CURRENT_USER);
        CurrentPass = PlayerPrefs.GetString(AuthConstant.CURRENT_PASS);
    }

    public void SetDataSystem()
    {
        PlayerPrefs.SetString(AuthConstant.CURRENT_USER, Email.text);
        PlayerPrefs.SetString(AuthConstant.CURRENT_PASS, Password.text);
    }

    private void Start()
    {
        GetDataSystem();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (email_focused)
            {
                Password.Select();

            } else if (pass_focused)
            {
                InvokePost();
            }
        }
        
        email_focused = Email.isFocused;
        pass_focused = Password.isFocused;
    }

    public void InvokePost()
    {
        StartCoroutine(ExecutePost());
    }

    IEnumerator ExecutePost()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", Email.text);
        form.AddField("password", Password.text);

        using (UnityWebRequest www = UnityWebRequest.Post(URL+Segment, form))
        {
            yield return www.SendWebRequest();

            //-- 2019
            if (www.isNetworkError || www.isHttpError)
            {
                RequestStatus = www.error;
            }
            else
            {
                RequestStatus = www.downloadHandler.text;
            }

            Debug.Log(RequestStatus);

            if (RequestStatus == AuthConstant.LOGIN_SUCCESS)
            {
                SetDataSystem();
                LoginSuccessEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.LOGIN_FAILED)
            {
                LoginFailureEvent.Invoke();
            }
            else 
            {
                UnknownEvent.Invoke();
            }


            /* 2021
            if (www.result != UnityWebRequest.Post.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
            */
        }
    }
}
