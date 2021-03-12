using System;
using System.IO;
using UnityEngine;

namespace TDSCommon
{
    public class BridgeEditor : IBridge
    {
        private static BridgeEditor sInstance = new BridgeEditor();

        private BridgeCallInterceptor mInterceptor;

        public static BridgeEditor GetInstance()
        {
            return sInstance;
        }

        public void EditorInterceptor(BridgeCallInterceptor interceptor)
        {
            this.mInterceptor = interceptor;
        }

        public void Register(string serviceClzName, string serviceImplName)
        {
            Debug.Log($"[TDSSDK-C#]Register serviceClzName: {serviceClzName}, serviceImplName: {serviceImplName}");
        }

        public void Call(Command command)
        {
            Debug.Log($"[TDSSDK-C#]Call, command: {command.toJSON()}");
            if (mInterceptor != null)
            {
                mInterceptor.Interceptor(command);
            }
        }

        public void Call(Command command, Action<Result> action)
        {
            Debug.Log($"[TDSSDK-C#]Call with action, command: {command.toJSON()}");
            if (mInterceptor != null)
            {
                mInterceptor.Interceptor(command, action);
            }
        }
    }
}