using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSBridge
{

    public class EngineBridge
    {
        private volatile static EngineBridge sInstance;

        private IBridge bridge;

        private static readonly object locker = new object();

        public static EngineBridge GetInstance()
        {
            lock (locker)
            {
                if (sInstance == null)
                {
                    sInstance = new EngineBridge();
                }
            }
            return sInstance;
        }

        private EngineBridge()
        {
#if UNITY_EDITOR
#elif UNITY_ANDROID
            bridge = BridgeAndroid.GetInstance();
#elif UNITY_IOS
            bridge = BridgeIOS.GetInstance();
#endif
        }

        public void Register(string serviceClzName, string serviceImplName)
        {
#if UNITY_EDITOR
#endif
            bridge.Register(serviceClzName, serviceImplName);
        }

        public void RegisterCallback(Action<Result> action)
        {
#if UNITY_EDITOR
#endif
            bridge.Register(action);
        }

        public void CallHandler(Command command)
        {
#if UNITY_EDITOR
#endif
            bridge.Call(command);
        }

        public void CallHandler(Command command, Action<Result> action)
        {
#if UNITY_EDITO
#endif
            bridge.Call(command, action);
        }


    }

}