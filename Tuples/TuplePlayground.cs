using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    public class TuplePlayground
    {
        //Not item1, item2, item3 and is a value type
        public (string Name, DateTime DateOfBirth, bool IsCustomer) GetCustomerInfo()
        {
            var person = new Person("John", new DateTime(1950, 01, 01), true);
            
            return (Name: person.FirstName, DateOfBirth: person.DateOfBirth, IsCustomer: person.IsCustomer);
        }

        public (string Name, DateTime DateOfBirth) ConvertTupleReferenceToValueTuple(Tuple<string, DateTime> tuple) => (tuple.Item1, tuple.Item2);

        //Cannot do (var name, var dob, *) = new Person("Richard", new DateTime(), true);
        public void TupleAssign()
        {
            var person = GetCustomerInfo();
            (string, DateTime, bool) person2 = GetCustomerInfo();

            string name = ConvertTupleReferenceToValueTuple(new Tuple<string, DateTime>(person.Name, person.DateOfBirth)).Name;
        }
    }
}
