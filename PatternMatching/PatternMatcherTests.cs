using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternMatching
{
    [TestClass]
    public class PatternMatcherTests
    {
        [TestMethod]
        public void ReflectPerson()
        {
            var person = new Person
            {
                FirstName = "John",
                DateOfBirth = new DateTime(1991, 02, 22, 00, 00, 00),
                Title = Title.Mr,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Line1 = "1 Street",
                        HouseNumber = 1,
                        IsCurrentAddress = true
                    },
                    new Address
                    {
                        Line1 = "2 Street",
                        HouseNumber = 2,
                        IsCurrentAddress = false
                    }
                }
            };
            
            var patternMatcher = new PatternMatcher();
            var result = patternMatcher.ReflectPerson(person);

        }
    }
}
