using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


namespace TDSCommon
{
    public class BridgeEditor : IBridge
    {
        private static BridgeEditor sInstance = new BridgeEditor();

        private List<BridgeEditorCallInterceptor> mInterceptorList;

        private Dictionary<string, Action<Result>> mMockResultDic;

        private BridgeEditor()
        {
            mMockResultDic = new Dictionary<string, Action<Result>>();
            mInterceptorList = new List<BridgeEditorCallInterceptor>();
        }

        public static BridgeEditor GetInstance()
        {
            return sInstance;
        }

        public void AddEditorInterceptor(BridgeEditorCallInterceptor interceptor)
        {
            if (!mInterceptorList.Contains(interceptor))
            {
                mInterceptorList.Add(interceptor);
            }
        }

        public void Register(string serviceClzName, string serviceImplName)
        {
            Debug.Log($"[TapSDK-C#]Register serviceClzName: {serviceClzName}, serviceImplName: {serviceImplName}");
        }

        public void Call(Command command)
        {
            Debug.Log($"[TapSDK-C#]Call, command: {command.toJSON()}");

            if (mInterceptorList != null)
            {
                foreach (BridgeEditorCallInterceptor interceptor in mInterceptorList)
                {
                    interceptor.BridgeInterceptor(command);
                }
            }
        }

        public void Call(Command command, Action<Result> action)
        {
            Debug.Log($"[TapSDK-C#]Call with action, command: {command.toJSON()}");

            if (mInterceptorList != null)
            {
                foreach (BridgeEditorCallInterceptor interceptor in mInterceptorList)
                {
                    interceptor.BridgeInterceptor(command, action);
                }
            }

        }
    }
}