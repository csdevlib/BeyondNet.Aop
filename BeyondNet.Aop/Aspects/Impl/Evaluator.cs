﻿using BeyondNet.Aop.Aspects.Interfaces;
using BeyondNet.Aop.Core.Interfaces;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BeyondNet.Aop.Aspects.Impl
{
    public class Evaluator : IEvaluator
    {
        public TOutput Evaluate<TOutput>(IJoinPoint joinPoint, string expression, TOutput errorvalue = default(TOutput))
        {
            try
            {
                var list = new List<ParameterExpression>();

                var infos = joinPoint.MethodInfo.GetParameters();

                for (int i = 0; i < infos.Length; i++)
                {
                    var info = infos[i];

                    list.Add(Expression.Parameter(info.ParameterType, info.Name));
                }

                var lambda = DynamicExpressionParser.ParseLambda(list.ToArray(), null, expression);

                var value = lambda.Compile().DynamicInvoke(joinPoint.Arguments);

                return (TOutput)Convert.ChangeType(value, typeof(TOutput));
            }
            catch (Exception ex)
            {
                return errorvalue;
            }
        }
    }
}
