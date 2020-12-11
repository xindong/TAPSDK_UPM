using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{

    [Serializable]
    public class Command
    {
        [SerializeField]
        public string service;
        [SerializeField]
        public string method;
        [SerializeField]
        public string args;
        [SerializeField]
        public bool callback;
        [SerializeField]
        public string callbackId;

        public Command()
        {

        }

        public Command(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        public string toJSON()
        {
            return JsonUtility.ToJson(this);
        }

        public Command(string service, string method, bool callback, string callbackId, Dictionary<string, object> dic)
        {
            this.args = dic == null ? null : Json.Serialize(dic);
            this.service = service;
            this.method = method;
            this.callback = callback;
            this.callbackId = callbackId;
            Debug.Log("Command constructor:" + toJSON());
        }

    }

}