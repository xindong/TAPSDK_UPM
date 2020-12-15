using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

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
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.name = SafeDictionary.SafeGetValueByKey(dic,"name") as string;
            this.avatar = SafeDictionary.SafeGetValueByKey(dic,"avatar") as string;
            this.openid = SafeDictionary.SafeGetValueByKey(dic,"openid") as string;
            this.unionid = SafeDictionary.SafeGetValueByKey(dic,"unionid") as string;
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}