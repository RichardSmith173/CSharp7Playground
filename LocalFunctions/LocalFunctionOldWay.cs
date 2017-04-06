using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions
{
    public class LocalFunctionOldWay
    {
        //old way
        public IEnumerable<T> FilterByMatchingNoException<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var element in source)
            {
                if (filter(element))
                {
                    yield return element;
                }
            }
        }

        public IEnumerable<T> FilterByMatchingWithException<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return IterateThroughCollection(source, filter);
        }

        private static IEnumerable<T> IterateThroughCollection<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            return source.Where(filter);
        }
    }
}
