using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using UniRx.Async.Internal;
using UnityEngine;

namespace TaskLike.Runtime.CompilerService
{
    [StructLayout(LayoutKind.Auto)]
    public struct TaskLikeMethodBuilder
    {
        AsyncTaskMethodBuilder methodBuilder;
        bool haveResult;
        bool useBuilder;

        public static TaskLikeMethodBuilder Create()
        {
            return new TaskLikeMethodBuilder();
        }

        public TaskLike Task
        {
            get
            {
                if (haveResult)
                {
                    return default;
                }
                else
                {
                    useBuilder = true;
                    return new TaskLike();
                }
            }
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        public void SetStateMatchine(IAsyncStateMachine stateMachine)
        {
        }


        /// <summary>Marks the task as successfully completed.</summary>
        public void SetResult()
        {
            if (useBuilder)
            {
                methodBuilder.SetResult();
            }
            else
            {
                haveResult = true;
            }
        }

        /// <summary>Marks the task as failed and binds the specified exception to the task.</summary>
        /// <param name="exception">The exception to bind to the task.</param>
        public void SetException(Exception exception) => methodBuilder.SetException(exception);


        /// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes.</summary>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            useBuilder = true;
            methodBuilder.AwaitOnCompleted(ref awaiter, ref stateMachine);
        }

        /// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes.</summary>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            useBuilder = true;
            methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
        }
    }
}