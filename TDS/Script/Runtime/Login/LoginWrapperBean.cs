using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public class LoginWrapperBean<T>
    {
        public T wrapper;

        public int loginCallbackCode;

        public LoginWrapperBean(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }

        public LoginWrapperBean()
        {
            
        }

    }
}