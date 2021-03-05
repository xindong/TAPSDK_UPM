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

        private IDynamicSuperProperties dynamicSuperProperties;

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

        public void RegisterStaticProperties(string superProperties)
        {
            Dictionary<string,object> dic = new Dictionary<string,object>();
            dic.Add("registerStaticProperties",superProperties);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE,"registerStaticProperties",false,dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void UnregisterStaticProperty(string propertyName)
        {
            Dictionary<string,object> dic = new Dictionary<string,object>();
            dic.Add("unregisterStaticProperty",propertyName);
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE,"unregisterStaticProperty",false,dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void RegisterDynamicProperties(IDynamicSuperProperties properties)
        {
            this.dynamicSuperProperties = properties;
        }
        
        public void ClearStaticProperties()
        {
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE,"clearStaticProperties",false,null);
            EngineBridge.GetInstance().CallHandler(command);
        }
        public void ClearUser() 
        {
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE,"clearUser",false,null);
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
            Dictionary<string,object> deserializeProperties = Json.Deserialize(properties) as Dictionary<string,object>;
            dic.Add("properties", GetFinalEventProperties(deserializeProperties));
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "onEvent", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void Track(string eventName, string properties)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("eventName", eventName);
            Dictionary<string, object> deserializeProperties = Json.Deserialize(properties) as Dictionary<string, object>;
            dic.Add("properties", GetFinalEventProperties(deserializeProperties));
            Command command = new Command(TDSTapDBConstants.TDS_TAPDB_SERVICE, "track", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void DeviceInitialize(string properties)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("deviceInitialize")
                                        .Args("deviceInitialize",properties)
                                        .Callback(true)
                                        .CommandBuilder());
        }

        public void DeviceUpdate(string properties)
        {   
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("deviceUpdate")
                                        .Args("deviceUpdate",properties)
                                        .CommandBuilder());
        }

        public void DeviceAdd(string properties)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("deviceAdd")
                                        .Args("deviceAdd",properties)
                                        .CommandBuilder());
        }

        public void UserInitialize(string properties)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("userInitialize")
                                        .Args("userInitialize",properties)
                                        .CommandBuilder());
        }

        public  void UserUpdate(string properties)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("userUpdate")
                                        .Args("userUpdate",properties)
                                        .CommandBuilder());
        }

        public void UserAdd(string properties)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("userAdd")
                                        .Args("userAdd",properties)
                                        .CommandBuilder());
        }

        public void EnableLog(bool enable)
        {
            EngineBridge.GetInstance().CallHandler(new Command.Builder()
                                        .Service(TDSTapDBConstants.TDS_TAPDB_SERVICE)
                                        .Method("enableLog")
                                        .Args("enableLog",enable)
                                        .CommandBuilder());
        }

        private string GetFinalEventProperties(Dictionary<string,object> properties)
        {
            if(dynamicSuperProperties!=null)
            {
                Dictionary<string,object> finalProperties = new Dictionary<string,object>();
                TDSPropertiesChecker.MergeProperties(dynamicSuperProperties.GetDynamicSuperProperties(),properties);
                TDSPropertiesChecker.MergeProperties(properties, finalProperties);
                return Json.Serialize(finalProperties);
            }
            return Json.Serialize(properties);
        }
    }
}