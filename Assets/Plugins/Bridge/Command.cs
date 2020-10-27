using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSBridge
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

    }

}