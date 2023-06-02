using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rhys.EFCore.Extensions.Core
{
    internal class LambdaExpressionGenerator
    {
        public static LambdaExpression CreateLambdaExpression<T>(PropertyInfo property)
        {
            // 创建实体类的参数表达式
            ParameterExpression param = Expression.Parameter(typeof(T), "e");
            // 创建属性访问的成员表达式
            MemberExpression propertyAccess = Expression.Property(param, property);
            // 创建 Lambda 表达式
            LambdaExpression lambda = Expression.Lambda(propertyAccess, param);
            // 转换 Lambda 表达式为具体的泛型类型
            return lambda;
        }
    }
}
