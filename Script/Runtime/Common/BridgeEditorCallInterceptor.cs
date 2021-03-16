using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public interface BridgeEditorCallInterceptor
    {

        void BridgeInterceptor(Command command, Action<Result> action);

        void BridgeInterceptor(Command command);

    }
}