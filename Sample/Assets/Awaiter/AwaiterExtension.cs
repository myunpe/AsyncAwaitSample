using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AwaiterExtensions
{
    public static class AwaiterExtension
    {
        public static TaskAwaiter<Object> GetAwaiter(this ResourceRequest operation)
        {
            var tcs = new TaskCompletionSource<Object>();
            
            Action<AsyncOperation> callback = null;

            callback = (op) =>
            {
                var req = op as ResourceRequest;
                op.completed -= callback;
                tcs.SetResult(req.asset);
            };
            operation.completed += callback;

            return tcs.Task.GetAwaiter();
        }
    }
}