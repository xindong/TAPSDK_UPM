using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public class MomentCallbackBean
    {

        public string code;

        public string message;

        public MomentCallbackBean(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }
}