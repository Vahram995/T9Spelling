using System;
using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ResponseModels;
using T9Spelling.Services.Abstraction;
using T9Spelling.Services.Implementation;
using Xunit;

namespace T9Spelling.Tests
{
    public class T9ServiceTests
    {
        private readonly IT9SpellingService _service;

        public T9ServiceTests()
        {
            _service = new T9SpellingService();
        }

        [Fact]
        public void ConvertToT9_HelloWorld_ReturnsExpectedResult()
        {
            // Arrange
            var input = new T9SpellingRequestModel("hello world");
            var expected = new T9SpellingResponseModel("4433555 555666096667775553");

            // Act
            var result = _service.ConvertToT9(input);

            // Assert
            Assert.Equal(expected.ConvertedText, result.ConvertedText);
        }

        [Fact]
        public void ConvertToT9_Yes_ReturnsExpectedResult()
        {
            // Arrange
            var input = new T9SpellingRequestModel("yes");
            var expected = new T9SpellingResponseModel("999337777");

            // Act
            var result = _service.ConvertToT9(input);

            // Assert
            Assert.Equal(expected.ConvertedText, result.ConvertedText);
        }

        [Fact]
        public void ConvertToT9_SingleCharacter_ReturnsCorrectDigit()
        {
            // Arrange
            var input = new T9SpellingRequestModel("a");
            var expected = new T9SpellingResponseModel("2");

            // Act
            var result = _service.ConvertToT9(input);

            // Assert
            Assert.Equal(expected.ConvertedText, result.ConvertedText);
        }

        [Fact]
        public void ConvertToT9_ConsecutiveCharactersSameKey_ReturnsWithSpace()
        {
            var input = new T9SpellingRequestModel("hi");
            var expected = new T9SpellingResponseModel("44 444");

            var result = _service.ConvertToT9(input);

            Assert.Equal(expected.ConvertedText, result.ConvertedText);
        }

        [Fact]
        public void ConvertToT9_UnsupportedCharacter_ThrowsArgumentException()
        {
            var input = new T9SpellingRequestModel("hello!");
            Assert.Throws<KeyNotFoundException>(() => _service.ConvertToT9(input));
        }

        [Fact]
        public void ConvertToT9_EmptyString_ReturnsEmptyString()
        {
            var input = new T9SpellingRequestModel("");
            var expected = new T9SpellingResponseModel("");

            var result = _service.ConvertToT9(input);

            Assert.Equal(expected.ConvertedText, result.ConvertedText);
        }
    }
}
