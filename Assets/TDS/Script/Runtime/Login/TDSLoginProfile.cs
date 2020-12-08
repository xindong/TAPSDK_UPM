using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace TapSDK
{   
    [Serializable]
    public class TDSLoginProfile
    {
        public string name;
        public string avatar;
        public string openid;
        public string unionid;

        public TDSLoginProfile(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}