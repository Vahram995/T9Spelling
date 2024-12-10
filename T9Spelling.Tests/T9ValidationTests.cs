using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ValidationModels;
using Xunit;

namespace T9Spelling.Tests
{
    public class T9ValidationTests
    {
        private readonly T9ValidationModel _validator;

        public T9ValidationTests()
        {
            _validator = new T9ValidationModel();
        }

        [Fact]
        public void Should_Have_Error_When_Text_Is_Empty()
        {
            // Arrange
            var model = new T9SpellingRequestModel { Text = "" };

            // Act
            var result = _validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_Have_Error_When_Text_Is_Null()
        {
            // Arrange
            var model = new T9SpellingRequestModel { Text = null };

            // Act
            var result = _validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_Have_Error_When_Text_Too_Long()
        {
            // Arrange: Create a string of length 1001
            var longText = new string('a', 1001);
            var model = new T9SpellingRequestModel { Text = longText };

            // Act
            var result = _validator.Validate(model);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_Pass_For_Valid_Text()
        {
            // Arrange
            var model = new T9SpellingRequestModel { Text = "hello" };

            // Act
            var result = _validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Should_Pass_For_Max_Length_Text()
        {
            // Arrange: Create a string of length exactly 1000
            var maxText = new string('a', 1000);
            var model = new T9SpellingRequestModel { Text = maxText };

            // Act
            var result = _validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
