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
            this.name = SafeDictionary.GetValue<string>(dic,"name") as string;
            this.avatar = SafeDictionary.GetValue<string>(dic,"avatar") as string;
            this.openid = SafeDictionary.GetValue<string>(dic,"openid") as string;
            this.unionid = SafeDictionary.GetValue<string>(dic,"unionid") as string;
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}