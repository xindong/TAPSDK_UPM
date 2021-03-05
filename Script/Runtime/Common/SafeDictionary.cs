using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class SafeDictionary
    {
        public static T GetValue<T> (Dictionary<string, object> dic, string key)
        {
            object outputValue;
            if (dic.TryGetValue(key,out outputValue))
            {
                if(typeof(T) == typeof(int)){
                    return (T)(object)int.Parse(outputValue.ToString());
                }else if(typeof(T) == typeof(double)){
                    return (T)(object)double.Parse(outputValue.ToString());
                }else if(typeof(T) == typeof(long)){
                    return (T)(object)long.Parse(outputValue.ToString());
                }else if(typeof(T) == typeof(bool)){
                    return  (T)(object)outputValue;
                }
                return (T) outputValue;
            }
            return default(T);
        }
    }
}