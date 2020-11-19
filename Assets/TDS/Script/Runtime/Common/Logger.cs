using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class Logger
    {

        public static void Init(string sdkName, string sdkVersionCode, string sdkVersionName)
        {
            LoggerHolder.GetInstance().Init(sdkName, sdkVersionCode, sdkVersionName);
        }

        public static void Log(string sdkName, string tag, string message)
        {
            LoggerHolder.GetInstance().Log(sdkName, tag, message);
        }

    }

    public class LoggerHolder
    {

        private Dictionary<string, LoggerImpl> loggerDic;

        public static LoggerHolder sInstance = new LoggerHolder();

        public static LoggerHolder GetInstance()
        {
            return sInstance;
        }

        private LoggerHolder()
        {
            loggerDic = new Dictionary<string, TDSCommon.LoggerImpl>();
            EngineBridge.GetInstance().Register("com.tds.common.log.wrapper.LoggerService", "com.tds.common.log.wrapper.LoggerServiceImpl");
        }

        public void Init(string sdkName, string sdkVersionCode, string sdkVersionName)
        {
            if (loggerDic.ContainsKey(sdkName))
            {
                return;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("sdkName", sdkName);
            dic.Add("sdkVersionCode", sdkVersionCode);
            dic.Add("sdkVersionName", sdkVersionName);
            loggerDic.Add(sdkName, new LoggerImpl(Json.Serialize(dic)));
        }

        public void Log(string sdkName, string tag, string message)
        {
            if (loggerDic.ContainsKey(sdkName))
            {
                loggerDic[sdkName].Log(tag, message);
            }
        }

    }

    public class LoggerImpl : ILogger
    {

        private string config;

        public LoggerImpl(string config)
        {
            this.config = config;
        }

        public void Log(string tag, string message)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["config"] = this.config;
            dic["tag"] = tag;
            dic["message"] = message;
            Command command = new Command("TDSLoggerService", "log", false, null, dic);
            EngineBridge.GetInstance().CallHandler(command);
        }

    }

    interface ILogger
    {
        void Log(string tag, string message);
    }

}