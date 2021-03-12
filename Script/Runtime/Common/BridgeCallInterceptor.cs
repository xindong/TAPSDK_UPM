using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public interface BridgeCallInterceptor
    {
        void Interceptor(Command command, Action<Result> action);

        void Interceptor(Command command);
    }
}