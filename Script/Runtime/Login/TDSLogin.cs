using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TapSDK
{
    public class TDSLogin
    {
        public static void Init(string clientId)
        {
            TDSLoginImpl.GetInstance().Init(clientId);
        }

        public static void Init(string clientId, bool isCN, bool isRoundCorner)
        {
            TDSLoginImpl.GetInstance().Init(clientId, isCN, isRoundCorner);
        }

        public static void StartLogin(string[] permissions)
        {
            TDSLoginImpl.GetInstance().StartLogin(permissions);
        }

        public static void RegisterLoginCallback(LoginCallback callback)
        {
            TDSLoginImpl.GetInstance().RegisterLoginCallback(callback);
        }

        public static void UnRegisterLoginCallback()
        {
            TDSLoginImpl.GetInstance().UnRegisterLoginCallback();
        }

        public static void GetCurrentAccessToken(Action<TDSAccessToken> callback)
        {
            TDSLoginImpl.GetInstance().GetCurrentAccessToken(callback);
        }

        public static void GetCurrentProfile(Action<TDSLoginProfile> callback)
        {
            TDSLoginImpl.GetInstance().GetCurrentProfile(callback);
        }

        public static void Logout()
        {
            TDSLoginImpl.GetInstance().Logout();
        }

        public static void FetchProfileForCurrentAccessToken(Action<TDSLoginProfile> callback, Action<string> errorCallback)
        {
            TDSLoginImpl.GetInstance().FetchProfileForCurrentAccessToken(callback, errorCallback);
        }

        public static void ChangeConfig(bool roundCorner, bool isPortrait)
        {
            TDSLoginImpl.GetInstance().ChangeConfig(roundCorner, isPortrait);
        }
    }
}