using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class TDSTapDBImpl : ITDSTapDB
    {
        private TDSTapDBImpl()
        {
            EngineBridge.GetInstance().Register(TDSTapDBConstants.TDS_TAPDB_CLZ, TDSTapDBConstants.TDS_TAPDB_IMPL);
        }

        private volatile static TDSTapDBImpl sInstance;

        private static readonly object locker = new object();

        public static TDSTapDBImpl GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new TDSTapDBImpl();
                }
            }
            return sInstance;
        }

        public void Init(string clientId, string channel, string gameVersion)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("clientId", clientId);
            dic.Add("channel", channel);
            dic.Add("gameVersion", gameVersion);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "init", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void SetUser(string userId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userId", userId);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "setUser", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void SetUser(string userId, string loginType)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userId", userId);
            dic.Add("loginType", loginType);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "setUserWithParams", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void SetName(string name)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("name", name);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "setName", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void SetLevel(int level)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("level", level);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "setLevel", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void SetServer(string server)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("server", server);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "setServer", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void OnCharge(string orderId, string product, long amount, string currencyType, string payment)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("orderId", orderId);
            dic.Add("product", product);
            dic.Add("amount", amount);
            dic.Add("currencyType", currencyType);
            dic.Add("payment", payment);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "onCharge", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void OnEvent(string eventCode, string properties)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("eventCode", eventCode);
            dic.Add("properties", properties);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "onEvent", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

    }
}