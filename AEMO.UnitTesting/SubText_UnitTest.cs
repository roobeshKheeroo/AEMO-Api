using code_challenge.Controllers;
using FluentAssertions; // Add this to resolve the 'Should' extension method  

namespace AEMO.UnitTesting
{
    public class SubText_UnitTest
    {
        private readonly SearchUtilController _controller;

        public SubText_UnitTest()
        {
            _controller = new SearchUtilController();
        }

        [Fact]
        public async Task SearchSubText_ShouldReturnCorrectPositions_WhenSubTextExists()
        {
            // Arrange  
            string mainText = "This is a simple test. Test is simple.";
            string subText = "test";

            // Act  
            var result = await _controller.SearchSubText(mainText, subText);

            // Assert  
            result.Should().Equal(new int[] { 18, 24 }); // "test" at position 18 and 24  
        }

        [Fact]
        public async Task SearchSubText_ShouldReturnEmptyArray_WhenSubTextDoesNotExist()
        {
            // Arrange
            string mainText = "Hello World";
            string subText = "xyz";

            // Act
            var result = await _controller.SearchSubText(mainText, subText);

            // Assert
            result.Should().BeEmpty();
        }

   

        [Fact]
        public async Task SearchSubText_ShouldHandleEmptyMainText()
        {
            // Arrange
            string mainText = "";
            string subText = "test";

            // Act
            Func<Task> result = () => _controller.SearchSubText(mainText, subText);

            // Assert
            await result.Should().ThrowAsync<ArgumentNullException>();
        }
       
    }
}