using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAsyncReturnTypes
{
    public class GeneralAsyncReturnTypes
    {
        public int CachedResult { get; set; }

        //Before - even if i know the value, because i return a task IL will instantiate a task method builder 
        public async Task<long> GetRowCountOld(Func<int, bool> predicate)
        {
            return CachedResult == 0 ? await Task.Run(() => CachedResult = new Repository().Query(predicate).Count()) : CachedResult;
        }

        //After - Not much different, just the return type
        public async ValueTask<long> GetRowCountNew(Func<int, bool> predicate)
        { 
            return CachedResult == 0 ? await Task.Run(() => CachedResult = new Repository().Query(predicate).Count()) : CachedResult;
        }
    }

    public class Repository
    {
        public IEnumerable<int> Database { get; set; }

        public IEnumerable<int> Query(Func<int, bool> predicate) => Database.Where(predicate);
    }
}
