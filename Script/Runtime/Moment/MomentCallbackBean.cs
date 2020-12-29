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
            Debug.Log("callbackCode:" + dic["code"] +   "  msg:" + dic["message"]);
            this.code = SafeDictionary.GetValue<int>(dic, "code");
            this.message = SafeDictionary.GetValue<string>(dic,"message");
        }

    }
}