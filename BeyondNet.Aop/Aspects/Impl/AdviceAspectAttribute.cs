using BeyondNet.Aop.Core.Impl;

namespace BeyondNet.Aop.Aspects.Impl
{
    public class AdviceAspectAttribute : AbstractAspectAttribute
    {
        public Type Type { get; set; }

        public bool HandleException { get; set; }

        public object[] Context { get; set; }
    }
}
