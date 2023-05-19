using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public class TDSTapDB
    {
        public static void Init(string clientId, string channel, string gameVersion)
        {
            TDSTapDBImpl.GetInstance().Init(clientId, channel, gameVersion);
        }

        public static void SetUser(string userId)
        {
            TDSTapDBImpl.GetInstance().SetUser(userId);
        }

        public static void SetUser(string userId, string loginType)
        {
            TDSTapDBImpl.GetInstance().SetUser(userId, loginType);
        }

        public static void SetName(string name)
        {
            TDSTapDBImpl.GetInstance().SetName(name);
        }

        public static void SetLevel(int level)
        {
            TDSTapDBImpl.GetInstance().SetLevel(level);
        }

        public static void SetServer(string server)
        {
            TDSTapDBImpl.GetInstance().SetServer(server);
        }

        public static void OnCharge(string orderId, string productId, long amount, string currencyType, string payment)
        {
            TDSTapDBImpl.GetInstance().OnCharge(orderId, productId, amount, currencyType, payment);
        }

        public static void OnEvent(string eventCode, string properties)
        {
            TDSTapDBImpl.GetInstance().OnEvent(eventCode, properties);
        }

        public static void Track(string eventName, string properties)
        {
            TDSTapDBImpl.GetInstance().Track(eventName, properties);
        }
    
        public static void RegisterStaticProperties(string properties)
        {
            TDSTapDBImpl.GetInstance().RegisterStaticProperties(properties);
        }

        public static void UnregisterStaticProperty(string propertKey)
        {
            TDSTapDBImpl.GetInstance().UnregisterStaticProperty(propertKey);
        }

        public static void RegisterDynamicProperties(IDynamicSuperProperties properties)
        {
            TDSTapDBImpl.GetInstance().RegisterDynamicProperties(properties);
        }

        public static void ClearStaticProperties()
        {
            TDSTapDBImpl.GetInstance().ClearStaticProperties();
        }

        public static void DeviceInitialize(string properties)
        {
            TDSTapDBImpl.GetInstance().DeviceInitialize(properties);
        }

        public static void DeviceUpdate(string properties)
        {
            TDSTapDBImpl.GetInstance().DeviceUpdate(properties);
        }

        public static void DeviceAdd(string properties)
        {
            TDSTapDBImpl.GetInstance().DeviceAdd(properties);
        }

        public static void UserInitialize(string properties)
        {
            TDSTapDBImpl.GetInstance().UserInitialize(properties);
        }

        public static void UserUpdate(string properties)
        {
            TDSTapDBImpl.GetInstance().UserUpdate(properties);
        }

        public static void UserAdd(string properties)
        {
            TDSTapDBImpl.GetInstance().UserAdd(properties);
        }

        public static void EnableLog(bool enable)
        {
            TDSTapDBImpl.GetInstance().EnableLog(enable);
        }

        public static void ClearUser() 
        {
            TDSTapDBImpl.GetInstance().ClearUser();
        }
    
        public static void AdvertiserIDCollectionEnabled(bool enable)
        {
            TDSTapDBImpl.GetInstance().AdvertiserIDCollectionEnabled(enable);
        }

        public static void SetOAIDCert(string cert){
            TDSTapDBImpl.GetInstance().SetOAIDCert(cert);
        }
    }
}