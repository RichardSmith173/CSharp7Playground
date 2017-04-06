using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions
{
    public class LocalFunctionNewWay
    {
        public IEnumerable<T> FilterByMatching<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return IterateThroughCollection();

            IEnumerable<T> IterateThroughCollection()
            {
                foreach (var element in source)
                {
                    if (filter(element))
                    {
                        yield return element;
                    }
                }
            }
        }

        //Nested private functions using async
        public Task<T> PerformSomethingExpensive<T>(IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return PerformLongRunningTask();

            async Task<T> PerformLongRunningTask()
            {
                return await BigTask<T>();

                Task<T> BigTask<T>()
                {
                    //something expensive in here...
                    throw new NotImplementedException();
                }
            }
        }
    }
}
