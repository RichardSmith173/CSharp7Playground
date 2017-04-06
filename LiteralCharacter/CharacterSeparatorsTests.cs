using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiteralCharacter
{
    [TestClass]
    public class CharacterSeparatorsTests
    {
        [TestMethod]
        public void ReturnCharacterSeparatedNumberAsString()
        {
            var separator = new CharacterSeparators();
            var result = separator.ReturnLargeNumberInNiceFormat(123456789);

            Assert.AreEqual("123_456_789", result);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ReturnCharacterSeparatedNumberThrowsException()
        {
            var separator = new CharacterSeparators();
            var result = separator.ReturnLargeNumberInNiceFormatWillThrowException(123456789);

            Assert.AreEqual(123_456_789, result);
        }

        [TestMethod]
        public void ReturnCharacterSeparatedNumberUsesExtension()
        {
            var separator = new CharacterSeparators();
            var result = separator.ReturnLargeNumberInNiceFormatUsingExtension(123456789);

            Assert.AreEqual(123_456_789, result);
            Assert.IsInstanceOfType(result, typeof(long));
        }
    }
}
