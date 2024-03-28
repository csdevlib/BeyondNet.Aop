﻿using BeyondNet.Aop.Core.Impl;
using System;

namespace BeyondNet.Aop.Aspects.Impl
{
    public class LoggerAspectAttribute : AbstractAspectAttribute
    {
        public Type Type { get; set; }

        public string[] LogArguments { get; set; }

        public bool LogReturn { get; set; }

        public bool LogDuration { get; set; }

        public bool LogException { get; set; }

        public string Expression { get; set; }
    }
}
