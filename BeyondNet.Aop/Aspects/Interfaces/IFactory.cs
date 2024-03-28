using BeyondNet.Aop.Core.Interfaces;

namespace BeyondNet.Aop.Aspects.Interfaces
{
    public interface IFactory<T>
    {
        T Create(IJoinPoint joinPoint, Type type);
    }
}
