using System;

namespace LiteralCharacter
{
    public class CharacterSeparators
    {
        //annoying that i have to return it as a string
        public string ReturnLargeNumberInNiceFormat(long bigNumber)
        {
            var numberAsString = bigNumber.ToString();
            var numberOfUnderscores = (numberAsString.Length - 3) / 3;

            for (var i = 1; i <= numberOfUnderscores; i++)
            {
                numberAsString = numberAsString.Insert((numberAsString.Length - (3 * i) - (i - 1)), "_");
            }

            return numberAsString;
        }

        //Unable to cast back to long
        public long ReturnLargeNumberInNiceFormatWillThrowException(long bigNumber)
        {
            var numberAsString = bigNumber.ToString();
            var numberOfUnderscores = (numberAsString.Length - 3) / 3;

            for (var i = 1; i <= numberOfUnderscores; i++)
            {
                numberAsString = numberAsString.Insert((numberAsString.Length - (3 * i) - (i - 1)), "_");
            }

            return long.Parse(numberAsString);
        }

        //Uses extension to cast back to long, but cannot have a long in a nice format.
        public long ReturnLargeNumberInBadFormatUsingExtension(long bigNumber)
        {
            var numberAsString = bigNumber.ToString();
            var numberOfUnderscores = (numberAsString.Length - 3) / 3;

            for (var i = 1; i <= numberOfUnderscores; i++)
            {
                numberAsString = numberAsString.Insert((numberAsString.Length - (3 * i) - (i - 1)), "_");
            }
            
            return numberAsString.ParseWithoutSeparator<long>();
        }
    }

    public static class CharacterSeparatorExtensions
    {
        public static T ParseWithoutSeparator<T>(this string number)
        {
            return (T)Convert.ChangeType(string.Join(string.Empty, number.Split('_')), typeof(T));
        }
    }
}
