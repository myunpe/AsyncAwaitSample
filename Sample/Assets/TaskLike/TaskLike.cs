using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaskLike.Runtime.CompilerService;
using UnityEngine;

namespace TaskLike
{
    
    [AsyncMethodBuilder(typeof(TaskLikeMethodBuilder))]
    public readonly struct TaskLike : IEquatable<TaskLike>
    {
        public bool Equals(TaskLike other)
        {
            throw new NotImplementedException();
        }
    }

}
