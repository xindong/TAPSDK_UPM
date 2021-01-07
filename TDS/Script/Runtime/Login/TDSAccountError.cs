

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class TDSAccountError
    {   

        public static string LOGIN_ERROR_INVALID_GRANT = "invalid_grant";

        public static string LOGIN_ERRROR_ACCESS_DENIED = "access_denied";

        public static string LOGIN_ERROR_FORBIDDEN = "forbidden";

        public static string LOGIN_ERROR_PERMISSION_RESULT="permission_result";

        public int code;
        public string msg;
        public string error;
        public string errorDescription;

        public TDSAccountError(Dictionary<string, object> dic)
        {
            this.code = SafeDictionary.GetValue<int>(dic, "code");
            this.msg = SafeDictionary.GetValue<string>(dic, "msg");
            this.error = SafeDictionary.GetValue<string>(dic, "error");
            this.errorDescription = SafeDictionary.GetValue<string>(dic, "errorDescription");
        }
        public TDSAccountError(string json)
        {
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            this.code = SafeDictionary.GetValue<int>(dic, "code");
            this.msg = SafeDictionary.GetValue<string>(dic, "msg");
            this.error = SafeDictionary.GetValue<string>(dic, "error");
            this.errorDescription = SafeDictionary.GetValue<string>(dic, "errorDescription");
        }
        
        public string ToJSON(){
            return JsonUtility.ToJson(this);
        }

    }
}