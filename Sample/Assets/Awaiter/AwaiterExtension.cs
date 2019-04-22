using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

namespace AwaiterExtensions
{
    public static class AwaiterExtension
    {
        public static TaskAwaiter<UnityEngine.Object> GetAwaiter(this ResourceRequest operation)
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

        public static TaskAwaiter<AsyncOperation> GetAwaiter(this AsyncOperation operation)
        {
            var tcs = new TaskCompletionSource<AsyncOperation>();

            Action<AsyncOperation> callback = null;
            callback = (op) =>
            {
                op.completed -= callback;
                tcs.SetResult(op);
            };

            operation.completed += callback;
            
            return tcs.Task.GetAwaiter();
        }
        
        public static TaskAwaiter<UnityWebRequest> GetAwaiter(this UnityWebRequestAsyncOperation operation)
        {
            var tcs = new TaskCompletionSource<UnityWebRequest>();

            Action<AsyncOperation> callback = null;
            callback = (op) =>
            {
                var request = op as UnityWebRequestAsyncOperation;
                op.completed -= callback;
                tcs.SetResult(request.webRequest);
            };

            operation.completed += callback;
            
            return tcs.Task.GetAwaiter();
        }
    }
}