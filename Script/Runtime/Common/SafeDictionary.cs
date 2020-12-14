using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class SafeDictionary
    {
        public static object SafeGetValueByKey(Dictionary<string, object> dic, string key)
        {
            object outputValue;
            if (dic.TryGetValue(key,out outputValue))
            {
                return outputValue;
            }
            return null;
        }
    }
}