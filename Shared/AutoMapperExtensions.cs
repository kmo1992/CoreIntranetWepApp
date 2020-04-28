using AutoMapper;
using System.ComponentModel;
using System.Linq;

namespace Shared
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreReadOnly<TSource, TDestination>(
                  this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destProperties = typeof(TDestination).GetProperties();

            foreach (var property in sourceType.GetProperties())
            {
                if (destProperties.Where(x => x.Name == property.Name).FirstOrDefault() != null)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                    ReadOnlyAttribute attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                    if (attribute.IsReadOnly == true)
                        expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}
