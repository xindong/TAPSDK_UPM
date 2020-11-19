using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
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
            if (TDSCommon.Platform.isAndroid())
            {
                bridge = BridgeAndroid.GetInstance();
            }
            else if (TDSCommon.Platform.isIOS())
            {
                bridge = BridgeIOS.GetInstance();
            }
        }

        public void Register(string serviceClzName, string serviceImplName)
        {
            if (bridge == null)
            {
                return;
            }
            bridge.Register(serviceClzName, serviceImplName);
        }

        public void RegisterCallback(Action<Result> action)
        {
            if (bridge == null)
            {
                return;
            }
            bridge.Register(action);
        }

        public void CallHandler(Command command)
        {
            if (bridge == null)
            {
                return;
            }
            bridge.Call(command);
        }

        public void CallHandler(Command command, Action<Result> action)
        {
            if (bridge == null)
            {
                return;
            }
            bridge.Call(command, action);
        }


    }

}