﻿/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menampilkan nilai score
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class VarScore : MonoBehaviour
    {

        [Space(10)]
        public bool isEnabled;

        public GlobalVariable.CInvokeType InvokeType;
        public GlobalVariable.CDataExecution ExecutionType;
        public bool ShowDebugLog;

        public float CurrentValue;
        float TotalScore;
        bool StartTransferAdd = false;
        bool StartTransferSub = false;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        public bool usingEvents;
        public UnityEvent Events;


        public void SetPrefCurrentValue(string aID)
        {
            PlayerPrefs.SetFloat(aID, CurrentValue);
        }

        public void GetPrefCurrentValue(string aID)
        {
            if (PlayerPrefs.HasKey(aID))
            {
                CurrentValue = PlayerPrefs.GetFloat(aID);
            }
        }

        public void SaveVariable()
        {
            PlayerPrefs.SetFloat(transform.gameObject.name, CurrentValue);
        }

        public void SaveVariableDebug()
        {
            PlayerPrefs.SetFloat(transform.gameObject.name, CurrentValue);
            Debug.Log("Save Variable [" + transform.gameObject.name + "]: " + CurrentValue.ToString());
        }

        public void LoadVariable()
        {
            CurrentValue = PlayerPrefs.GetFloat(transform.name);
        }

        public void LoadVariableDebug()
        {
            CurrentValue = PlayerPrefs.GetFloat(transform.name);
            Debug.Log("Load Variable [" + transform.gameObject.name + "]: " + CurrentValue.ToString());
        }


        public float GetCurrentValue()
        {
            return CurrentValue;
        }

        public void OutputFromCurrentValue(InputField aValue)
        {
            aValue.text = CurrentValue.ToString();
        }

        public void OutputFromCurrentValue(Text aValue)
        {
            aValue.text = CurrentValue.ToString();
        }

        public void OutputFromCurrentValue(TextMesh aValue)
        {
            aValue.text = CurrentValue.ToString();
        }


        //-- Current Value Standard
        public void SetCurrentValue(float aValue)
        {
            CurrentValue = aValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public void AddToCurrentValue(float aValue)
        {
            CurrentValue += aValue;
        }

        public void TransferAddToCurrentValue(float aValue)
        {
            TotalScore = CurrentValue + aValue;
            StartTransferAdd = true;
            Invoke("ThreeSecond", 3);
        }

        public void TransferSubFromCurrentValue(float aValue)
        {
            TotalScore = CurrentValue - aValue;
            StartTransferSub = true;
            Invoke("ThreeSecond", 3);
        }

        void ThreeSecond()
        {
            CurrentValue = TotalScore;
        }

        public void SubtractFromCurrentValue(float aValue)
        {
            CurrentValue -= aValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        //-- Current Value VarTime
        public void SetCurrentValue(VarTime aValue)
        {
            CurrentValue = aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public void AddToCurrentValue(VarTime aValue)
        {
            CurrentValue += aValue.CurrentValue;
        }

        public void AddToCurrentValue10(VarTime aValue)
        {
            CurrentValue += aValue.CurrentValue * 10;
        }

        public void AddToCurrentValue100(VarTime aValue)
        {
            CurrentValue += aValue.CurrentValue * 100;
        }

        public void AddToCurrentValue1000(VarTime aValue)
        {
            CurrentValue += aValue.CurrentValue * 1000;
        }

        public void SubtractFromCurrentValue(VarTime aValue)
        {
            CurrentValue -= aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        //-- Current Value VarScore
        public void SetCurrentValue(VarScore aValue)
        {
            CurrentValue = aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public void AddToCurrentValue(VarScore aValue)
        {
            CurrentValue += aValue.CurrentValue;
        }

        public void SubtractFromCurrentValue(VarScore aValue)
        {
            CurrentValue -= aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        //-- Current Value VarFloat
        public void SetCurrentValue(VarFloat aValue)
        {
            CurrentValue = aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public void AddToCurrentValue(VarFloat aValue)
        {
            CurrentValue += aValue.CurrentValue;
        }

        public void SubtractFromCurrentValue(VarFloat aValue)
        {
            CurrentValue -= aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        //-- Current Value VarInt
        public void SetCurrentValue(VarInteger aValue)
        {
            CurrentValue = aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public void AddToCurrentValue(VarInteger aValue)
        {
            CurrentValue += aValue.CurrentValue;
        }

        public void SubtractFromCurrentValue(VarInteger aValue)
        {
            CurrentValue -= aValue.CurrentValue;
            if (CurrentValue <= 0) CurrentValue = 0;
        }

        public bool IsShutdown()
        {
            return CurrentValue <= 0;
        }

        public void InputToCurrentValue(InputField aValue)
        {
            if (aValue.contentType == InputField.ContentType.DecimalNumber)
            {
                CurrentValue = float.Parse(aValue.text);
            }
            else
            {
                Debug.Log("Error type: Invalid InputField.ContentType.DecimalNumber");
            }
        }

        public void SaveData()
        {
            SetPrefCurrentValue(this.transform.name);
            if (ShowDebugLog)
            {
                Debug.Log("Save data " + this.transform.name + " = " + CurrentValue.ToString());
            }
            if (usingEvents)
            {
                Events.Invoke();
            }
        }

        public void LoadData()
        {
            GetPrefCurrentValue(this.transform.name);
            if (ShowDebugLog)
            {
                Debug.Log("Load data " + this.transform.name + " = " + CurrentValue.ToString());
            }
            if (usingEvents)
            {
                Events.Invoke();
            }
        }

        public void InvokeExecutionData()
        {
            if (ExecutionType == GlobalVariable.CDataExecution.Save && isEnabled)
            {
                SaveData();
            }
            else if (ExecutionType == GlobalVariable.CDataExecution.Load && isEnabled)
            {
                LoadData();
            }
        }

        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake && isEnabled)
            {
                InvokeExecutionData();
            }
        }

        void Start()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnStart && isEnabled)
            {
                InvokeExecutionData();
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnDelay && isEnabled)
            {
                if (usingDelay)
                {
                    Invoke("InvokeExecutionData", Delay);
                }
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnInterval && isEnabled)
            {
                if (usingInterval)
                {
                    InvokeRepeating("InvokeExecutionData", 1, Interval);
                }
            }
        }

        void Update()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnUpdate && isEnabled)
            {
                InvokeExecutionData();
            }
            if (StartTransferAdd)
            {
                CurrentValue += 1f;
                if (CurrentValue > TotalScore)
                {
                    CurrentValue = TotalScore;
                    StartTransferAdd = false;
                }
            }
            if (StartTransferSub)
            {
                CurrentValue -= 1f;
                if (CurrentValue < TotalScore)
                {
                    CurrentValue = TotalScore;
                    StartTransferAdd = false;
                }
            }
        }

    }
}