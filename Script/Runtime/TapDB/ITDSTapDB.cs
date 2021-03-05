using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public interface ITDSTapDB
    {
        void Init(string clientId, string channel, string gameVersion);

        void SetUser(string userId);

        void SetUser(string userId, string loginType);

        void SetName(string name);

        void SetLevel(int level);

        void SetServer(string server);

        void OnCharge(string orderId, string product, long amount, string currencyType, string payment);

        void OnEvent(string eventCode, string properties);

        void Track(string eventName, string properties);

        void RegisterStaticProperties(string properties);

        void UnregisterStaticProperty(string propertKey);

        void RegisterDynamicProperties(IDynamicSuperProperties properties);

        void ClearStaticProperties();

        void DeviceInitialize(string properties);

        void DeviceUpdate(string properties);

        void DeviceAdd(string properties);

        void UserInitialize(string properties);

        void UserUpdate(string properties);

        void UserAdd(string properties);

        void EnableLog(bool enable);

        void ClearUser();
    }

    public interface IDynamicSuperProperties
    {
        Dictionary<string, object> GetDynamicSuperProperties();
    }

    public class TDSTapDBConstants
    {
        public static string TDS_TAPDB_SERVICE = "TDSTapDBService";

        public static string TDS_TAPDB_CLZ = "com.tds.tapdb.wrapper.TapDBService";

        public static string TDS_TAPDB_IMPL = "com.tds.tapdb.wrapper.TapDBServiceImpl";

    }

    public class TDSTapDBLoginType
    {
        public static string TapTap = "TapTap";

        public static string WeiXin = "WeiXin";

        public static string QQ = "QQ";

        public static string Tourist = "Tourist";

        public static string Apple = "Apple";

        public static string Alipay = "Alipay";

        public static string Facebook = "Facebook";

        public static string Google = "Google";

        public static string Twitter = "Twitter";

        public static string PhoneNumer = "PhoneNumber";

        public static string Custom = "Custom";
    }

}