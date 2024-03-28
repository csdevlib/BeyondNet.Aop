using System;

namespace BeyondNet.Aop.Core.Interfaces
{
    public interface IPointCut
    {
        bool CanApply(IJoinPoint joinPoint, Type type);
    }
}
