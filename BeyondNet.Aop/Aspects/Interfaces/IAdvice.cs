﻿using BeyondNet.Aop.Core.Interfaces;
using System;

namespace BeyondNet.Aop.Aspects.Interfaces
{
    public interface IAdvice
    {
        void OnSuccess(IJoinPoint joinpoint, object[] context);

        void OnEntry(IJoinPoint joinpoint, object[] context);

        void OnExit(IJoinPoint joinpoint, object[] context);

        void OnException(IJoinPoint joinpoint, object[] context, Exception ex);
    }
}
