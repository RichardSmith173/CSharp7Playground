using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalFunctions
{
    [TestClass]
    public class LocalFunctionTests
    {
        //this won't fail as i never iterate through the list, so the null check in the method never happens
        [TestMethod]
        public void TestLocalFunctionWithNull()
        {
            var localFunction = new LocalFunctionOldWay();
            localFunction.FilterByMatchingNoException<string>(null, x => x == "John");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestLocalFunctionWithNullThrowsException()
        {
            var localFunction = new LocalFunctionOldWay();
            localFunction.FilterByMatchingWithException<string>(null, x => x == "John");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestLocalFunctionWithNullNowThrowsException()
        {
            var localFunction = new LocalFunctionNewWay();
            localFunction.FilterByMatching<string>(null, x => x == "John");
        }
    }
}
