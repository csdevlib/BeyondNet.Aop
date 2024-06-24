using BeyondNet.Aop.Demo.Impl;
using BeyondNet.Aop.Demo.Interfaces;
using BeyondNet.Aop.Logger;
using LightInject;


namespace BeyondNet.Aop.Demo
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDoSomething, DoWriteMessage1>(new PerContainerLifetime());

            serviceRegistry.Register<ISerializer, JsonSerializer>(typeof(JsonSerializer).FullName, new PerContainerLifetime());
        }
    }
}
