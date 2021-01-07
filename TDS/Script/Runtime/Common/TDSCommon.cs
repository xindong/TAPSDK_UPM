using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class TDSCommon
    {
        public static void SetLanguage(string language)
        {
            TDSCommonImpl.GetInstance().SetLanguage(language);
        }

        public static void GetRegionCode(Action<bool> callback)
        {
            TDSCommonImpl.GetInstance().GetRegionCode(callback);
        }
    }
}