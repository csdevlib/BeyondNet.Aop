using BeyondNet.Aop.Aspects.Impl;
using BeyondNet.Aop.Aspects.Interfaces;
using BeyondNet.Aop.Core.Impl;
using BeyondNet.Aop.Core.Interfaces;
using BeyondNet.ServiceLocator.Installer;
using BeyondNet.ServiceLocator.Interfaces;
using Jal.Aop.LightInject;
using LightInject;

namespace BeyondNet.Aop.Installer
{
    public static class ServiceContainerExtension
    {
        public static void AddAop(this IServiceContainer container, Action<IAopAspectsBuilder> action = null, bool automaticInterception = true)
        {
            container.AddServiceLocator();

            var types = new List<Type>();

            var builder = new AopAspectsBuilder(container, types);

            builder.AddAspect<LoggerAspect>();

            builder.AddAspect<AdviceAspect>();

            builder.AddAspect<RetryAspect>();

            if (action != null)
            {
                action(builder);
            }

            container.Register<IPointCut, PointCut>(new PerContainerLifetime());

            container.Register<IAspectExecutor>(factory => new AspectExecutor(builder.Types.ToArray(), factory.GetInstance<IServiceLocator>(), factory.GetInstance<IPointCut>()), new PerContainerLifetime());

            container.Register<AopProxy>();

            container.Register<IFactory<IAdvice>, Factory<IAdvice>>(new PerContainerLifetime());

            container.Register<IFactory<ILogger>, Factory<ILogger>>(new PerContainerLifetime());

            container.Register<IEvaluator, Evaluator>(new PerContainerLifetime());

            container.Register<IAdvice, Advice>(typeof(Advice).FullName, new PerContainerLifetime());

            if (automaticInterception)
            {
                container.RegisterFrom<AutomaticInterceptionCompositionRoot>();
            }
        }
    }
}