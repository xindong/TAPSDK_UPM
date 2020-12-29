using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    [Serializable]
    public class TDSAccessToken
    {
        [SerializeField]
        public string kid;
        [SerializeField]
        public string access_token;
        [SerializeField]
        public string token_type;
        [SerializeField]
        public string mac_key;
        [SerializeField]
        public string mac_algorithm;

        public TDSAccessToken(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.kid = SafeDictionary.GetValue<string>(dic,"kid") as string;
            this.access_token = SafeDictionary.GetValue<string>(dic,"access_token") as string;
            this.token_type = SafeDictionary.GetValue<string>(dic,"token_type") as string;
            this.mac_key = SafeDictionary.GetValue<string>(dic,"mac_key") as string;
            this.mac_algorithm = SafeDictionary.GetValue<string>(dic,"mac_algorithm") as string;
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }
}