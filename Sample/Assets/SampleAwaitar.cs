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


    public class ResourceRequestAwaiter : IAwaitar<UnityEngine.GameObject>
    {
        private ResourceRequest resourceRequest;

        public ResourceRequestAwaiter(ResourceRequest resourceRequest)
        {
            this.resourceRequest = resourceRequest;
        }

        public bool IsCompleted => resourceRequest?.isDone ?? true;

        void IAwaitar<GameObject>.OnCompleted(Action continuation)
        {
            
            continuation?.Invoke();
        }

        public GameObject GetResult()
        {
            return resourceRequest.asset as GameObject;
        }

        void INotifyCompletion.OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }
    }
}