using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TDSCommon;

namespace TapSDK
{
    public class TDSLoginImpl : ITDSLogin
    {

        private TDSLoginImpl()
        {
            EngineBridge.GetInstance().Register(TDSLoginConstants.TDS_LOGIN_SERVICE_CLZ, TDSLoginConstants.TDS_LOGIN_SERVICE_IMPL);
        }

        private volatile static TDSLoginImpl sInstance;

        private static readonly object locker = new object();

        public static TDSLoginImpl GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new TDSLoginImpl();
                }
            }
            return sInstance;
        }

        public void Init(string clientId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("clientID", clientId);
            Command command = new Command(TDSLoginConstants.TDS_LOGIN_SERVICE, "init", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void Init(string clientId, bool isCN, bool roundCorner)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("clientID", clientId);
            dic.Add("regionType", isCN);
            dic.Add("roundCorner", roundCorner);
            Command command = new Command(TDSLoginConstants.TDS_LOGIN_SERVICE, "initWithClientID", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void ChangeConfig(bool isCN, bool roundCorner)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("regionType", isCN);
            dic.Add("roundCorner", roundCorner);
            Command command = new Command(TDSLoginConstants.TDS_LOGIN_SERVICE, "changeConfig", false, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void StartLogin(string[] permissions)
        {
            Command command = new Command.Builder()
                .Service(TDSLoginConstants.TDS_LOGIN_SERVICE)
                .Method("startTapLogin")
                .Args("permissions", permissions)
                .CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void RegisterLoginCallback(LoginCallback callback)
        {
            Command command = new Command.Builder()
                        .Service(TDSLoginConstants.TDS_LOGIN_SERVICE)
                        .Method("registerLoginCallback")
                        .Callback(true)
                        .OnceTime(false)
                        .CommandBuilder();

            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                TDSLoginResultHandler.HandlerLoginResult(callback, result);
            });
        }

        public void UnRegisterLoginCallback()
        {
            Command command = new Command(TDSLoginConstants.TDS_LOGIN_SERVICE, "unregisterLoginCallback", false, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

        public void GetCurrentAccessToken(Action<TDSAccessToken> callback)
        {
            Command command = new Command.Builder()
                                .Service(TDSLoginConstants.TDS_LOGIN_SERVICE)
                                .Method("currentAccessToken")
                                .Callback(true)
                                .OnceTime(true).CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                Debug.Log("accessToken:" + result.toJSON());
                if (result.code != Result.RESULT_SUCCESS)
                {
                    callback(null);
                    return;
                }

                if (string.IsNullOrEmpty(result.content))
                {
                    callback(null);
                    return;
                }
                Debug.Log("content:" + result.content);
                TDSAccessToken accessToken = new TDSAccessToken(result.content);
                callback(accessToken);
            });
        }

        public void GetCurrentProfile(Action<TDSLoginProfile> callback)
        {
            Command command = new Command.Builder()
                                .Service(TDSLoginConstants.TDS_LOGIN_SERVICE)
                                .Method("currentProfile")
                                .Callback(true)
                                .OnceTime(true)
                                .CommandBuilder();

            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                Debug.Log("currentProfile:" + result.toJSON());
                if (result.code != Result.RESULT_SUCCESS)
                {
                    callback(null);
                    return;
                }

                if (string.IsNullOrEmpty(result.content))
                {
                    callback(null);
                    return;
                }

                TDSLoginProfile profile = new TDSLoginProfile(result.content);
                callback(profile);
            });
        }

        public void FetchProfileForCurrentAccessToken(Action<TDSLoginProfile> profileCallback, Action<string> errorCallback)
        {
            Command command = new Command.Builder()
                                .Service(TDSLoginConstants.TDS_LOGIN_SERVICE)
                                .Method("fetchProfileForCurrentAccessToken")
                                .OnceTime(true)
                                .Callback(true)
                                .CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command, (result) =>
            {
                if (result.code != Result.RESULT_SUCCESS)
                {
                    errorCallback(result.message);
                    return;
                }

                if (string.IsNullOrEmpty(result.content))
                {
                    errorCallback(result.message);
                    return;
                }
                LoginWrapperBean<string> wrapperBean = new LoginWrapperBean<string>(result.content);
                if (wrapperBean.loginCallbackCode == 0)
                {
                    TDSLoginProfile profile = new TDSLoginProfile(wrapperBean.wrapper);
                    profileCallback(profile);
                    return;
                }
                errorCallback(wrapperBean.wrapper);
            });
        }
        public void Logout()
        {
            Command command = new Command(TDSLoginConstants.TDS_LOGIN_SERVICE, "logout", false, null);
            EngineBridge.GetInstance().CallHandler(command);
        }

    }
}