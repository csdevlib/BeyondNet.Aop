using BeyondNet.Aop.Core.Interfaces;


namespace BeyondNet.Aop.Aspects.Interfaces
{
    public interface IAopAspectsBuilder
    {
        IAopAspectsBuilder AddAdvice<TImplementation>()
            where TImplementation : class, IAdvice;

        IAopAspectsBuilder AddLogger<TImplementation>()
            where TImplementation : class, ILogger;

        IAopAspectsBuilder AddAspect<TImplementation>()
            where TImplementation : class, IAspect;

        List<Type> Types { get; }
    }
}
