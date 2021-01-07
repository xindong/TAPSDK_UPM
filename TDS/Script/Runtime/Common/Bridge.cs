using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

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
            if (Platform.isAndroid())
            {
                bridge = BridgeAndroid.GetInstance();
            }
            else if (Platform.isIOS())
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