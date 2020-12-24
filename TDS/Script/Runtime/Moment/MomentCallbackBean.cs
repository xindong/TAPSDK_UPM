using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class MomentCallbackBean
    {

        public int code;

        public string message;

        public MomentCallbackBean(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.code = int.Parse(SafeDictionary.SafeGetValueByKey(dic, "code").ToString());
            this.message = SafeDictionary.SafeGetValueByKey(dic,"message").ToString();
        }

    }
}