using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TDSCommon
{

    [Serializable]
    public class Result
    {

        public static int RESULT_SUCCESS = 0;

        public static int RESULT_ERROR = -1;

        [SerializeField]
        public int code;

        [SerializeField]
        public string message;

        [SerializeField]
        public string content;

        [SerializeField]
        public string callbackId;

        public Result()
        {

        }

        public Result(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }

    }

}