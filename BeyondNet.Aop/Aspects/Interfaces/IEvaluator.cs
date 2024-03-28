using BeyondNet.Aop.Core.Interfaces;

namespace BeyondNet.Aop.Aspects.Interfaces
{
    public interface IEvaluator
    {
        TOutput Evaluate<TOutput>(IJoinPoint joinPoint, string expression, TOutput errorvalue = default(TOutput));
    }
}
