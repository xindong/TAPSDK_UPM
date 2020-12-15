

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class TDSAccountError
    {
        public int code;
        public string msg;
        public string error;
        public string errorDescription;
        public TDSAccountError(Dictionary<string, object> dic)
        {
            this.code = int.Parse(SafeDictionary.SafeGetValueByKey(dic, "code") as string);
            this.msg = SafeDictionary.SafeGetValueByKey(dic, "msg") as string;
            this.error = SafeDictionary.SafeGetValueByKey(dic, "error") as string;
            this.errorDescription = SafeDictionary.SafeGetValueByKey(dic, "errorDescription") as string;
        }
        public TDSAccountError(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.code = int.Parse(SafeDictionary.SafeGetValueByKey(dic, "code") as string);
            this.msg = SafeDictionary.SafeGetValueByKey(dic, "msg") as string;
            this.error = SafeDictionary.SafeGetValueByKey(dic, "error") as string;
            this.errorDescription = SafeDictionary.SafeGetValueByKey(dic, "errorDescription") as string;
        }
        public string ToJSON(){
            return Json.Serialize(this);
        }

    }
}