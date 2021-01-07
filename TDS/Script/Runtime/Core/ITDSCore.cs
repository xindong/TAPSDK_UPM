using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public interface ITDSCore
    {
        void Init(string clientID);

        void EnableMoment();

        void EnableTapDB(string gameVersion, string gameChannel);
    }

    public class TDSCoreConstants
    {
        public static string TDS_CORE_SERVICE = "TDSCoreService";

        public static string TDS_CORE_CLZ = "com.tds.wrapper.TDSCoreService";

        public static string TDS_CORE_IMPL = "com.tds.wrapper.TDSCoreServiceImpl";
    }   

}