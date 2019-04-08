using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;


namespace TaskLike
{
    public interface IAwaiter : ICriticalNotifyCompletion
    {
        bool IsCompleted { get; }
        void GetResult();
    }

    public interface IAwaiter<out T> : IAwaiter
    {
        new T GetResult();
    }

    public class CustomAwaiter : IAwaiter
    {
        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public bool IsCompleted { get; }

        public void GetResult()
        {
            throw new NotImplementedException();
        }
    }

    public enum AwaiterStatus
    {
        Pending = 0,
        Succeeded = 1,
        Faulted = 2,
        Canceled = 3
    }


//    public struct ResrouceRequestAwaiter : IAwaiter<UnityEngine.Object>
//    {
//        ResourceRequest asyncOperation;
//        Action<AsyncOperation> continuationAction;
//        UnityEngine.Object result;
//
//        public ResourceRequestAwaiter(ResourceRequest asyncOperation)
//        {
//            this.asyncOperation = asyncOperation;
//            this.result = asyncOperation.asset;
//            this.continuationAction = null;
//        }
//
//        public void OnCompleted(Action continuation)
//        {
//            throw new NotImplementedException();
//        }
//
//        public void UnsafeOnCompleted(Action continuation)
//        {
//            throw new NotImplementedException();
//        }
//
//        public bool IsCompleted { get; }
//        public Object GetResult()
//        {
//            throw new NotImplementedException();
//        }
//
//        Object IAwaiter<Object>.GetResult()
//        {
//            throw new NotImplementedException();
//        }
//
//        void IAwaiter.GetResult()
//        {
//            throw new NotImplementedException();
//        }
//    }
}