using BeyondNet.Aop.Core.Interfaces;
using System.Reflection;

namespace BeyondNet.Aop.Core.Impl
{
    /*
     Join Point: It is a point in the execution of a program, such as calling a method or throwing an exception.
     */
    public class JoinPoint : IJoinPoint
    {
        private object _returnValue;

        public object[] Arguments { get; set; }

        public MethodInfo MethodInfo { get; set; }

        public object Return
        {
            get
            {
                return _returnValue; 
                
            }
            set
            {
                _returnValue = value;

                if (UpdateProxyInvocation!=null)
                    UpdateProxyInvocation(value);
            }
        }

        public object TargetObject { get; set; }

        public Type TargetType { get; set; }

        public Action<JoinPoint> ExecuteProxyInvocation { get; set; }

        public Action<object> UpdateProxyInvocation { get; set; }

        public void Proceed()
        {
            if (ExecuteProxyInvocation!=null)
                ExecuteProxyInvocation(this);
        }
    }
}
