
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDSCommon
{
    public interface IBridge
    {
        void Register(string serviceClzName, string serviceImplName);

        void Call(Command command);

        void Call(Command command, Action<Result> action);
        
    }
}