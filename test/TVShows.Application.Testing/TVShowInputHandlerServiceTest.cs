using Telerik.JustMock;
using TVShows.Application.Common.Interfaces;
using TVShows.Application.DTOs;
using TVShows.Application.Services;

namespace TVShows.Application.Testing
{
    [TestFixture]
    public class TVShowInputHandlerServiceTest
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public async Task HandleUserInput_InvalidInput_ShouldReturnErrorMessage()
        {
            // Arrange
            string userInput = "list";
            var tVShowService = Mock.Create<ITVShowService>();
            var tvShowHandler = new TVShowInputHandlerService(tVShowService);

            // Act
            var result = await tvShowHandler.HandleUserInput(userInput);

            // Assert
            Assert.IsNotEmpty(result.Message);
            Assert.IsNotNull(result.Message);
            Assert.IsEmpty(result.TVShows);
        }

        [Test]
        public async Task HandleUserInput_ListCommand_ShouldReturnListOfTVShows()
        {
            // Arrange
            string userInput = "list";
            var tVShowService = Mock.Create<ITVShowService>();
            var tvShowHandler = new TVShowInputHandlerService(tVShowService);

            // Act
            var result = await tvShowHandler.HandleUserInput(userInput);

            // Assert
            Assert.IsNotNull(result.Message);
            Assert.IsNotNull(result.TVShows);
            Assert.That(result, Is.TypeOf<TVShowHandlerResultDTO>());
        }
    }
}
