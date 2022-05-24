using System.Reflection;

namespace AutoMapper
{
    /// <summary>
    /// CustomAutoMapper
    /// </summary>
    public static class CustomAutoMapper
    {
        /// <summary>
        /// IgnoreAllNonExisting
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            IMappingExpression<TSource, TDestination> mappingExpression = null;
            if (expression != null)
            {
                var flags = BindingFlags.Public | BindingFlags.Instance;
                var sourceType = typeof(TSource);
                var destinationProperties = typeof(TDestination).GetProperties(flags);

                foreach (var property in destinationProperties)
                {
                    if (sourceType.GetProperty(property.Name, flags) == null)
                    {
                        mappingExpression = expression.ForMember(property.Name, opt => opt.Ignore());
                    }
                }
            }
            return mappingExpression;
        }
    }
}
