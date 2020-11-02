using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TDSMoment
{
    public enum CallbackCode : int
    {
        CALLBACK_CODE_MOMENT_APPEAR = 30000,
        CALLBACK_CODE_MOMENT_DISAPPEAR = 30100,

        CALLBACK_CODE_PUBLISH_SUCCESS = 10000,
        CALLBACK_CODE_PUBLISH_FAIL = 10100,
        CALLBACK_CODE_PUBLISH_CANCEL = 10200,

        CALLBACK_CODE_GET_NOTICE_SUCCESS = 20000,
        CALLBACK_CODE_GET_NOTICE_FAIL = 20100
    }

    public class TDSMoment
    {

        public static void SetCallback(Action<int, string> callback)
        {
            MomentImpl.GetInstance().SetCallback(callback);
        }
        
    }
}