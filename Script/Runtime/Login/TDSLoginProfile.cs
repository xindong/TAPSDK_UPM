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
            this.name = dic["name"] as string;
            this.avatar = dic["avatar"] as string;
            this.openid = dic["openid"] as string;
            this.unionid = dic["unionid"] as string;
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}