using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public class TDSTapDB
    {
        public static void Init(string appId, string clientId, string channel, string gameVersion)
        {
            TDSTapDBImpl.GetInstance().Init(appId, clientId, channel, gameVersion);
        }

        public static void SetUser(string userId)
        {
            TDSTapDBImpl.GetInstance().SetUser(userId);
        }

        public static void SetUser(string userId, string openId, string loginType)
        {
            TDSTapDBImpl.GetInstance().SetUser(userId, openId, loginType);
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

        public static void OnCharge(string orderId, string productId, string amount, string currencyType, string payment)
        {
            TDSTapDBImpl.GetInstance().OnCharge(orderId, productId, amount, currencyType, payment);
        }

        public static void OnEvent(string eventCode, string properties)
        {
            TDSTapDBImpl.GetInstance().OnEvent(eventCode, properties);
        }
    }
}