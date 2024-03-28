using BeyondNet.Aop.Core.Interfaces;

namespace BeyondNet.Aop.Core.Impl
{
    /*
     Pointcut: It is an expression which will help us select one or more Join Points.  
     */
    public class PointCut : IPointCut
    {
        public bool CanApply(IJoinPoint joinPoint, Type aspectType)
        {
            ArgumentNullException.ThrowIfNull(joinPoint, nameof(joinPoint));
            ArgumentNullException.ThrowIfNull(aspectType.BaseType, nameof(aspectType.BaseType));

            if (aspectType.BaseType.IsGenericType)
            {
                var attibuteTypes = aspectType.BaseType.GetGenericArguments();
                if (attibuteTypes.Length > 0)
                {
                    var attibuteType = attibuteTypes.FirstOrDefault(x => typeof(AbstractAspectAttribute).IsAssignableFrom(x));
                    if (attibuteType != null)
                    {
                        var attributes = joinPoint.MethodInfo.GetCustomAttributes(attibuteType, true);
                        return attributes.Length > 0;
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }
    }
}
