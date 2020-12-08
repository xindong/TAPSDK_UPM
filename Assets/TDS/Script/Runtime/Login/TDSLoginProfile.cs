using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace TapSDK
{
    public class TDSLoginProfile
    {
        public string name;
        public string avatar;
        public string openid;
        public string unionid;
        public int isCertified = -1;
    
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