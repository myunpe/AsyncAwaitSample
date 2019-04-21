using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace Lib
{
    [AsyncMethodBuilder(typeof(AsyncTaskLikeMethodBuilder<>))]
    public partial struct TaskLike<TResult>
    {
    }

    public struct AsyncTaskLikeMethodBuilder<TResult>
    {
        public static AsyncTaskLikeMethodBuilder<TResult> Create() => new AsyncTaskLikeMethodBuilder<TResult>();

        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
        {
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        public void SetResult()
        {
        }

        public void SetException(Exception exception)
        {
        }

        public TaskLike<TResult> Task => default(TaskLike<TResult>);

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
        }
    }
}