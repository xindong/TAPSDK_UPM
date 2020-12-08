using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    [Serializable]
    public class TDSAccessToken
    {
        public string kid;
        public string access_token;
        public string token_type;
        public string mac_key;
        public string mac_algorithm;

        public TDSAccessToken(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}