using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public interface ITDSCommon
    {
        void SetLanguage(string language);

        void GetRegionCode(Action<bool> callback);
    }

    [Serializable]
    public class CommonRegionWrapper
    {
        public bool isMainland;

        public CommonRegionWrapper(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

    }

}