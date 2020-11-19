using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class Platform
    {
        public static bool isAndroid(){
            return Application.platform == RuntimePlatform.Android;
        }

        public static bool isIOS(){
            return Application.platform == RuntimePlatform.IPhonePlayer;
        }

    }
}