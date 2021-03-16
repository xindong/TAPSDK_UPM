using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK

{
    public class TDSCoreImpl : ITDSCore
    {

        private TDSCoreImpl()
        {
            EngineBridge.GetInstance().Register(TDSCoreConstants.TDS_CORE_CLZ, TDSCoreConstants.TDS_CORE_IMPL);
        }

        private volatile static TDSCoreImpl sInstance;

        private static readonly object locker = new object();

        public static TDSCoreImpl GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new TDSCoreImpl();
                }
            }
            return sInstance;
        }

        public void Init(string clientId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("clientID", clientId);
            Command command = new Command(TDSCoreConstants.TDS_CORE_SERVICE, "init", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void Init(string clientID, bool isCN)
        {
            Command command = new Command.Builder()
                .Service(TDSCoreConstants.TDS_CORE_SERVICE)
                .Method("initWithRegion")
                .Args("clientID", clientID)
                .Args("regionType", isCN)
                .CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void EnableMoment()
        {
            Command command = new Command(TDSCoreConstants.TDS_CORE_SERVICE, "enableMoment", false, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void EnableTapDB(string gameVersion, string gameChannel)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("gameVersion", gameVersion);
            dic.Add("gameChannel", gameChannel);
            Command command = new Command(TDSCoreConstants.TDS_CORE_SERVICE, "enableTapDB", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }


    }
}