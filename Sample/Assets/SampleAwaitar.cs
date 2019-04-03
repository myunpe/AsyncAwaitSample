using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace Lib
{
    public interface IAwaitar<T> : ICriticalNotifyCompletion
    {
        bool IsCompleted{ get; }
        void OnCompleted(Action continuation);
        T GetResult();
    }

    public class SampleAwaitar<T>
    {
    }
    
    
    
}