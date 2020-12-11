using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class MomentCallbackBean
    {

        public string code;

        public string message;

        public MomentCallbackBean(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.code = dic["code"] as string;
            this.message = dic["message"] as string;
        }

    }
}