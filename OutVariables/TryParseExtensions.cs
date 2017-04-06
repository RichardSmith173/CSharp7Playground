using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutVariables
{
    public static class TryParseExtensions
    {
        public static bool TryParse<TIn, TOut>(this TIn typeIn, out TOut result) where TOut : class
        {
            result = null;
            if (!(typeIn is TOut))
            {
                return false;
            }

            result = typeIn as TOut;
            return true;
        }
    }
}
