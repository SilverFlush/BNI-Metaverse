using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;

public class PasswordSystem : MonoBehaviour
{

    [Header("Server")]
    [TextArea(3, 4)]
    public string URL = "http://localhost/coder/api/post";
    public string ForgotSegment;
    public string ChangeSegment;

    [Header("Data")]
    public InputField Email;
    public InputField OldPassword;
    public InputField NewPassword;
    public InputField PasswordConfirmation;

    [Header("Events")]
    public UnityEvent InvalidOldPasswordEvent;
    public UnityEvent EmptyPasswordEvent;
    public UnityEvent InvalidConfirmationEvent;
    public UnityEvent ChangePassSuccessEvent;
    public UnityEvent ChangePassFailureEvent;
    public UnityEvent UnknownEvent;

    [Header("System")]
    public string CurrentUser;
    public string CurrentPass;

    string RequestStatus = "";
    bool oldpass_focused;
    bool newpass_focused;
    bool confirmpass_focused;


    public void GetDataSystem()
    {
        URL = PlayerPrefs.GetString(AuthConstant.CURRENT_SERVER);
        CurrentUser = PlayerPrefs.GetString(AuthConstant.CURRENT_USER);
        CurrentPass = PlayerPrefs.GetString(AuthConstant.CURRENT_PASS);
    }

    public void SetDataSystem()
    {
        PlayerPrefs.SetString(AuthConstant.CURRENT_USER, CurrentUser);
        PlayerPrefs.SetString(AuthConstant.CURRENT_PASS, NewPassword.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetDataSystem();    
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokePost()
    {
        if (isValidate())
        {
            StartCoroutine(ExecutePost());
        }
    }

    public void InvokeReset()
    {
        StartCoroutine(ExecuteMail());
    }

    bool isValidate()
    {
        bool result = true;

        if (NewPassword.text == "")
        {
            result = false;
            EmptyPasswordEvent.Invoke();
        }
        else if (NewPassword.text != PasswordConfirmation.text)
        {
            result = false;
            InvalidConfirmationEvent.Invoke();
        }

        return result;
    }

    IEnumerator ExecuteMail()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", CurrentUser);
        using (UnityWebRequest www = UnityWebRequest.Post(URL+ ForgotSegment, form))
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

            /*
            if (RequestStatus == AuthConstant.CHANGE_PASSWORD_SUCCESS)
            {
                SetDataSystem();
                ChangePassSuccessEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.CHANGE_PASSWORD_FAILED)
            {
                ChangePassFailureEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.OLD_PASSWORD_DIFFERENT)
            {
                InvalidOldPasswordEvent.Invoke();
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

    IEnumerator ExecutePost()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", CurrentUser);
        form.AddField("password", NewPassword.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URL + ChangeSegment, form))
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

            if (RequestStatus == AuthConstant.CHANGE_PASSWORD_SUCCESS)
            {
                SetDataSystem();
                ChangePassSuccessEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.CHANGE_PASSWORD_FAILED)
            {
                ChangePassFailureEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.OLD_PASSWORD_DIFFERENT)
            {
                InvalidOldPasswordEvent.Invoke();
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

            GetDataSystem();
        }
    }
}
