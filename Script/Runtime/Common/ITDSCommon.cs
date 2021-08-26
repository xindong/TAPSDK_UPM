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
            Dictionary<string,object> dic = Json.Deserialize(json) as Dictionary<string,object>;
            if (Platform.isAndroid())
            {
                this.isMainland = SafeDictionary.GetValue<bool>(dic,"isMainland");
            }else if (Platform.isIOS())
            {
                this.isMainland = SafeDictionary.GetValue<int>(dic, "isMainland") == 1;
            }
        }

    }

}