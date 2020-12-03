using System;
using System.Linq;
using System.Linq.Expressions;

namespace constraint
{
    public class ExpressionHelper
    {
        public static Expression<Func<T, object>> GetProperty<T>(string name)
        {
            var type = typeof(T);
            Expression<Func<T, object>> result = null;
            var parameter = Expression.Parameter(type);
            var lower_name = name.ToLower();
            var property_info = type.GetProperties().FirstOrDefault(p => p.Name.ToLower() == lower_name ) ;
            if (property_info != null)
            {
                var property_exp = Expression.Property(parameter, property_info);
                result = Expression.Lambda<Func<T, object>>(
                    Expression.Convert(property_exp, typeof(object)),
                    parameter);
            }
            return result;
        }
    }
}
