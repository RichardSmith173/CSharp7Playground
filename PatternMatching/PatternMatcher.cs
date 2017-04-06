using System;
using System.Collections.Generic;

namespace PatternMatching
{
    public class PatternMatcher
    {
        public IDictionary<string, object> ReflectPerson(Person person)
        {
            var result = new Dictionary<string, object>();
            foreach (var property in person.GetType().GetProperties().IgnoreCustomTypes())
            {
                if (property.GetValue(person) is string name)
                {
                    result.Add(property.Name, name);
                }
                else if (property.GetValue(person) is DateTime dateTime)
                {
                    result.Add(property.Name, dateTime);
                }
                else if (property.GetValue(person) is Enum title)
                {
                    Console.WriteLine(title);
                    result.Add(property.Name, title);
                }
            }

            result.Add(nameof(Person.Addresses), ReflectCurrentAddresses(person.Addresses));

            return result;
        }

        public IEnumerable<KeyValuePair<string, object>> ReflectCurrentAddresses<T>(IEnumerable<T> objects)
        {
            var result = new List<KeyValuePair<string, object>>();
            foreach (var objectToInspect in objects)
            {
                foreach (var property in objectToInspect.GetType().GetProperties())
                {
                    switch (property.GetValue(objectToInspect))
                    {
                        case string Name:
                            result.Add(new KeyValuePair<string, object>(property.Name, Name));
                            break;
                        case int Number:
                            result.Add(new KeyValuePair<string, object>(property.Name, Number));
                            break;
                        case bool Current when Current == true:
                            result.Add(new KeyValuePair<string, object>(property.Name, Current));
                            break;
                        case null:
                            break;
                    }
                }
            }

            return result;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Title Title { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public int HouseNumber { get; set; }
        public bool IsCurrentAddress { get; set; }
    }

    public enum Title
    {
        Mr,
        Mrs
    }
}
