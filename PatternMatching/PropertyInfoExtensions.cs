using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PatternMatching
{
    public static class PropertyInfoExtensions
    {
        public static IEnumerable<PropertyInfo> IgnoreCustomTypes(this IEnumerable<PropertyInfo> properties)
        {
            return properties.Where(x => x.PropertyType.Namespace != nameof(System));
        }
    }
}