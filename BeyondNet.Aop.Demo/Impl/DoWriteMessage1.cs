using BeyondNet.Aop.Aspects.Impl;
using BeyondNet.Aop.Demo.Interfaces;
using BeyondNet.Aop.Logger.Serilog;

namespace BeyondNet.Aop.Demo.Impl
{
    public class DoWriteMessage1 : IDoSomething
    {
        [LoggerAspect(Expression = "parameter.Id", Type = typeof(SerilogLogger), LogArguments = new string[] { "seed", "parameter" }, LogReturn = true, LogDuration = true, LogException = true)]
        public void Do()
        {
            Console.WriteLine("Doing Write Message 1");
        }
    }
}
