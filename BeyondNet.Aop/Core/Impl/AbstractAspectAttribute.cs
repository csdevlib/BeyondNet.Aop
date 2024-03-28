using System;

namespace BeyondNet.Aop.Core.Impl
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AbstractAspectAttribute : Attribute
    {
        public int Order { get; set; }
    }
}