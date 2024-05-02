using NUnit.Framework;

// ReSharper disable StringLiteralTypo
namespace LookingForChars.Tests
{
    [TestFixture]
    public class CharsCounterTests
    {
        [Test]
        public void GetMaxConsecutiveUnequalChars_EmptyString_ReturnsZero()
        {
            // Arrange
            string input = string.Empty;

            // Act
            int result = CharsCounter.GetMaxConsecutiveUnequalChars(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetMaxConsecutiveUnequalChars_SingleCharacter_ReturnsOne()
        {
            // Arrange
            string input = "a";

            // Act
            int result = CharsCounter.GetMaxConsecutiveUnequalChars(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetMaxConsecutiveUnequalChars_AllCharactersEqual_ReturnsOne()
        {
            // Arrange
            string input = "aaaaa";

            // Act
            int result = CharsCounter.GetMaxConsecutiveUnequalChars(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetMaxConsecutiveUnequalChars_SomeUnequalCharacters_ReturnsCorrectCount()
        {
            // Arrange
            string input = "aaaaabcddddddeeeeeeeee";

            // Act
            int result = CharsCounter.GetMaxConsecutiveUnequalChars(input);

            // Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Test_AllDifferentCharacters()
        {
            // Arrange
            string input = "abcdefg";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_AllSameCharacters()
        {
            // Arrange
            string input = "aaaaaaa";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Test_MixedCharacters()
        {
            // Arrange
            string input = "aaabbbccc";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Test_EmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_NullString()
        {
            // Arrange
            string input = null;

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_NonLatinCharacters()
        {
            // Arrange
            string input = "1234567890";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalLatinLetters(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_AllDifferentDigits()
        {
            // Arrange
            string input = "1234";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_AllSameDigits()
        {
            // Arrange
            string input = "1111111111";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Test_MixedDigits()
        {
            // Arrange
            string input = "11233444";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Test_EmptyDigitsString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_NullDigitsString()
        {
            // Arrange
            string input = null;

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_NonDigitCharacters()
        {
            // Arrange
            string input = "abcdefgh";

            // Act
            int result = CharsCounter.GetMaxConsecutiveIdenticalDigits(input);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
