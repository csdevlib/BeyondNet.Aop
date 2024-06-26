﻿namespace BeyondNet.Aop.Core.Interfaces
{
    public interface IAspect
    {
        void SetNext(IAspect aspect);

        IAspect GetNext();

        void Apply(IJoinPoint joinPoint);

        int GetOrder(IJoinPoint joinPoint);
    }
}
