using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public class BridgeAndroid : IBridge
    {

        private string bridgeJavaClz = "com.tds.common.bridge.Bridge";

        private string instanceMethod = "getInstance";

        private string registerHandlerMethod = "registerHandler";

        private string callHandlerMethod = "callHandler";
        
        private string initMethod = "init";

        private string registerMethod = "register";

        private AndroidJavaObject mCurrentActivity;

        private AndroidJavaObject mAndroidBridge;

        private static BridgeAndroid sInstance = new BridgeAndroid();

        public static BridgeAndroid GetInstance()
        {
            return sInstance;
        }

        private BridgeAndroid()
        {
            mCurrentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            mAndroidBridge = new AndroidJavaClass(bridgeJavaClz).CallStatic<AndroidJavaObject>(instanceMethod);
            mAndroidBridge.Call(initMethod, mCurrentActivity);
        }

        public void Register(string serviceClzName, string serviceImplName)
        {
            if (mAndroidBridge == null)
            {
                return;
            }
            AndroidJavaClass serviceClass = new AndroidJavaClass(serviceClzName);
            AndroidJavaObject serviceImpl = new AndroidJavaObject(serviceImplName);
            mAndroidBridge.Call(registerMethod, serviceClass, serviceImpl);
        }

        public void Call(Command command, Action<Result> action)
        {
            if (mAndroidBridge == null)
            {
                return;
            }
            mAndroidBridge.Call(registerHandlerMethod, command.toJSON(), new BridgeCallback(action));
        }

        public void Call(Command command)
        {
            if (mAndroidBridge == null)
            {
                return;
            }
            mAndroidBridge.Call(callHandlerMethod, command.toJSON());
        }

    }
}