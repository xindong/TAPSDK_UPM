using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public interface ITDSLogin
    {

        void Init(string clientId);

        void Init(string clientId, bool regionType, bool roundCorner);

        void ChangeConfig(bool roundCorner, bool isPortrait);

        void StartLogin(string[] permissions);

        void RegisterLoginCallback(LoginCallback callback);

        void UnRegisterLoginCallback();

        void GetCurrentAccessToken(Action<TDSAccessToken> token);

        void GetCurrentProfile(Action<TDSLoginProfile> profile);

        void FetchProfileForCurrentAccessToken(Action<TDSLoginProfile> profileCallback,Action<string> errorCallback);
        
        void Logout();
        
    }

    public class TDSLoginConstants
    {
        public static string TDS_LOGIN_SERVICE = "TDSLoginService";

        public static string TDS_LOGIN_SERVICE_CLZ = "com.taptap.sdk.wrapper.TDSLoginService";

        public static string TDS_LOGIN_SERVICE_IMPL = "com.taptap.sdk.wrapper.TDSLoginServiceImpl";

    }

    public interface LoginCallback
    {
        void LoginSuccess(TDSAccessToken accessToken);

        void LoginCancel();

        void LoginError(TDSAccountError error);
    }

}