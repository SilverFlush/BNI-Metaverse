using System;
using System.Text;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class RequestPost : MonoBehaviour
{
    [System.Serializable]
    public class CJsonData
    {
        public string ID;
        public string Name;
        public int FullBody;
        public int Gender;
        public int Hair;
        public int Head;
        public int Body;
        public int Leg;
        public int Shoe;
    }

    public void FullBody(int index)
    {
        PostJsonData.FullBody = index;
    }

    public void Gender(int index)
    {
        PostJsonData.Gender = index;
    }
    public void Hair(int index)
    {
        PostJsonData.Hair = index;
    }
    public void Head(int index)
    {
        PostJsonData.Head = index;
    }
    public void Body(int index)
    {
        PostJsonData.Body = index;
    }
    public void Leg(int index)
    {
        PostJsonData.Leg = index;
    }
    public void Shoe(int index)
    {
        PostJsonData.Shoe = index;
    }

    [Header("Server Settings")]
    public string ServerURL;

    [Header("POST Settings")]
    public string Data;

    [Header("JSON Settings")]
    public CJsonData PostJsonData;
    public CJsonData ResultJsonData;

    [Header("TOKEN Settings")]
    public string Token;
    public bool LoadFromPlayerPref;

    // Start is called before the first frame update
    void Start()
    {
        if (LoadFromPlayerPref)
        {
            Token = PlayerPrefs.GetString("TOKEN");
        }
    }

    public void InvokePOST()
    {
        StartCoroutine(POSTFunction());
    }

    public void InvokeJSON()
    {
        StartCoroutine(JSONFunction());
    }

    public void InvokeTOKEN()
    {
        StartCoroutine(TOKENFunction());
    }

    IEnumerator POSTFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL;

        //-- 2. prepare data
        WWWForm FormRequest = new WWWForm();
        FormRequest.AddField("data", Data);

        //-- 3. post request
        using (UnityWebRequest request = UnityWebRequest.Post(TargetServer, FormRequest))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                print(request.error.ToString());
            }
            else
            {
                string asset = request.downloadHandler.text;
                Debug.Log(asset);
            }
        }
    }

    IEnumerator JSONFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL;

        //-- 2. prepare data
        string JsonString = JsonUtility.ToJson(PostJsonData);

        //-- 3. post request
        using (UnityWebRequest request = UnityWebRequest.Post(TargetServer, JsonString))
        {
            byte[] JsonToSend = new System.Text.UTF8Encoding().GetBytes(JsonString);
            request.uploadHandler = new UploadHandlerRaw(JsonToSend);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                print(request.error.ToString());
            }
            else
            {
                string asset = request.downloadHandler.text;
                Debug.Log(asset);
                ResultJsonData = JsonUtility.FromJson<CJsonData>(asset);
            }
        }
    }

    IEnumerator TOKENFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL;

        //-- 2. prepare data
        string JsonString = JsonUtility.ToJson(PostJsonData);

        //-- 3. post request
        using (UnityWebRequest request = UnityWebRequest.Post(TargetServer, JsonString))
        {
            byte[] JsonToSend = new System.Text.UTF8Encoding().GetBytes(JsonString);
            request.uploadHandler = new UploadHandlerRaw(JsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer" + Token);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                print(request.error.ToString());
            }
            else
            {
                string asset = request.downloadHandler.text;
                Debug.Log(asset);
                ResultJsonData = JsonUtility.FromJson<CJsonData>(asset);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


