namespace BeyondNet.Aop.Core.Interfaces
{
    public interface IAspectExecutor
    {
        void Execute(IJoinPoint joinPoint);
    }
}
