using System;
using System.Text;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class RequestGet : MonoBehaviour
{
    [System.Serializable]
    public class CJsonData
    {
        public string ID;
        public string Name;
        public int Head;
        public int Body;
        public int Leg;
        public int Shoe;
    }

    [Header("Server Settings")]
    public string ServerURL;

    [Header("GET Settings")]
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

    public void InvokeGET()
    {
        StartCoroutine(GETFunction());
    }

    public void InvokeJSON()
    {
        StartCoroutine(JSONFunction());
    }

    public void InvokeTOKEN()
    {
        StartCoroutine(TOKENFunction());
    }

    IEnumerator GETFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL + "/" + Data;

        //-- 2. get request
        using (UnityWebRequest www = UnityWebRequest.Get(TargetServer))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error.ToString());
            }
            else
            {
                string asset = www.downloadHandler.text;
                Debug.Log(asset);
            }
        }
    }

    IEnumerator JSONFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL + "/" + Data;

        //-- 2. get request
        using (UnityWebRequest request = UnityWebRequest.Get(TargetServer))
        {
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

    IEnumerator TOKENFunction()
    {
        //-- 1. server url
        string TargetServer = "";
        TargetServer = ServerURL + "/" + Data;

        //-- 2. get request
        using (UnityWebRequest request = UnityWebRequest.Get(TargetServer))
        {
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
