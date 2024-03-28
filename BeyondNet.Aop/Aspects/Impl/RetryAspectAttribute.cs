using BeyondNet.Aop.Core.Impl;
using System;


namespace BeyondNet.Aop.Aspects.Impl
{
    public class RetryAspectAttribute : AbstractAspectAttribute
    {
        public int MaxAttempts { get; set; }

        public Type ExceptionType { get; set; }
    }
}
