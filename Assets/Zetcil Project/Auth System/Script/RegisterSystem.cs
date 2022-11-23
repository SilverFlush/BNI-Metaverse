using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class RegisterSystem : MonoBehaviour
{

    [Header("Server")]
    [TextArea(3, 4)]
    public string URL = "http://localhost/coder/api/post";
    public string Segment;

    [Header("Data")]
    public InputField Email;
    public InputField FirstName;
    public InputField LastName;
    public Toggle GenderM;
    public Toggle GenderF;
    public InputField Phone;
    public InputField Password;
    public InputField PasswordConfirmation;

    [Header("Events")]
    public UnityEvent InvalidEmailEvent;
    public UnityEvent EmptyFirstnameEvent;
    public UnityEvent EmptyPasswordEvent;
    public UnityEvent InvalidConfirmationEvent;
    public UnityEvent RegisterSuccessEvent;
    public UnityEvent RegisterFailureEvent;
    public UnityEvent UnknownEvent;

    [Header("System")]
    public string CurrentUser;
    public string CurrentPass;

    string RequestStatus = "";
    bool email_focused;
    bool first_focused;
    bool last_focused;
    bool phone_focused;
    bool pass_focused;
    bool passc_focused;

    public void ClearData()
    {
        Email.text = "";
        FirstName.text = "";
        LastName.text = "";
        GenderM.isOn = true;
        Phone.text = "";
        Password.text = "";
        PasswordConfirmation.text = "";
    }

    public void GetDataSystem()
    {
        URL = PlayerPrefs.GetString(AuthConstant.CURRENT_SERVER);
        CurrentUser = PlayerPrefs.GetString(AuthConstant.CURRENT_USER);
        CurrentPass = PlayerPrefs.GetString(AuthConstant.CURRENT_PASS);
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearData();
        GetDataSystem();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (email_focused)
            {
                FirstName.Select();

            }
            else if (first_focused)
            {
                LastName.Select();
            }
            else if (last_focused)
            {
                Phone.Select();
            }
            else if (phone_focused)
            {
                Password.Select();
            }
            else if (pass_focused)
            {
                PasswordConfirmation.Select();
            }
            else if (passc_focused)
            {
                InvokePost();
            }
        }

        email_focused = Email.isFocused;
        first_focused = FirstName.isFocused;
        last_focused = LastName.isFocused;
        phone_focused = Phone.isFocused;
        pass_focused = Password.isFocused;
        passc_focused = PasswordConfirmation.isFocused;
    }

    bool isValidate()
    {
        bool result = true;

        if (!Email.text.Contains("@"))
        {
            result = false;
            InvalidEmailEvent.Invoke();
        }
        else if (FirstName.text == "")
        {
            result = false;
            EmptyFirstnameEvent.Invoke();
        }
        else if (Password.text == "")
        {
            result = false;
            EmptyPasswordEvent.Invoke();
        }
        else if (Password.text != PasswordConfirmation.text)
        {
            result = false;
            InvalidConfirmationEvent.Invoke();
        }

        return result;
    }

    public void InvokePost()
    {
        if (isValidate())
        {
            StartCoroutine(ExecutePost());
        }
    }

    IEnumerator ExecutePost()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", Email.text);
        form.AddField("password", Password.text);
        form.AddField("first_name", FirstName.text);
        form.AddField("last_name", LastName.text);
        if (GenderM.isOn)
        {
            form.AddField("gender", "M");
        }
        if (GenderF.isOn)
        {
            form.AddField("gender", "F");
        }
        form.AddField("phone", Phone.text);
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

            if (RequestStatus == AuthConstant.CREATE_USER_SUCCESS)
            {
                RegisterSuccessEvent.Invoke();
            }
            else if (RequestStatus == AuthConstant.USERS_EXISTS)
            {
                RegisterFailureEvent.Invoke();
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
