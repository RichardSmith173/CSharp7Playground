using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExpressions
{
    public class ThrowExpressions
    {
        //Can't use in constructor for dependency checking
        //public ThrowExpressions(IEnumerable<int> dependency) => dependency ?? throw new ArgumentNullException();

        public ThrowExpressions(IEnumerable<int> dependency)
        {
            if (dependency == null)
            {
                throw new ArgumentNullException();
            }
        }

        public int CheckNumber(int number) => number > 0 ? number = 0 : throw new ArgumentOutOfRangeException();
    }
}
