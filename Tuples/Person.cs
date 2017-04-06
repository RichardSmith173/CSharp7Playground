using System;

namespace Tuples
{
    public class Person
    {
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCustomer { get; set; }

        public Person(string name, DateTime dob, bool isCustomer)
        {
            FirstName = name;
            dob = DateOfBirth;
            IsCustomer = isCustomer;
        }

        public void Deconstruct(out string name, out DateTime dob, out bool isCustomer)
        {
            name = FirstName;
            dob = DateOfBirth;
            isCustomer = IsCustomer;
        }
        
        public void Copy(Person person) => (person.FirstName, person.DateOfBirth, person.IsCustomer) = this;
    }
}