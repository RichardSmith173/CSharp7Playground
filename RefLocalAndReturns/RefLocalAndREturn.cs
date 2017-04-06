using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefLocalAndReturns
{
    //Taken from https://docs.microsoft.com/en-us/dotnet/articles/csharp/whats-new/csharp-7#ref-locals-and-returns
    public class RefLocalAndReturn
    {
        public static ref int FindWithRefReturn(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];

            throw new ArgumentException();
        }

        //Prints 42
        public void PrintNumber()
        {
            var matrix = new int[6, 6];
            var valItem = FindWithRefReturn(new int[6,6], (val) => val == 42);
            Console.WriteLine(valItem);
            valItem = 24;
            Console.WriteLine(matrix[4, 2]);
        }

        //Prints 24
        public void PrintRefNumber()
        {
            var matrix = new int[6, 6];
            ref var item = ref FindWithRefReturn(matrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[4, 2]);
        }
    }
}
