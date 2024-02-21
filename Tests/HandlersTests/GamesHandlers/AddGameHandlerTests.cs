using Gamestore.ApplicationServices.Handlers.Games;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Services.GameHandlerService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using Gamestore.DataAccess.Entities;
using Moq;

namespace Tests.HandlersTests.GamesHandlers;
[TestFixture]
public class AddGameHandlerTests
{
    private Mock<ICommandExecutor> _commandExecutor;
    private Mock<IGameHandlerService> _gameService;
    private AddGameHandler _addGameHandler;

    [SetUp]
    public void SetUp()
    {
        _gameService = new Mock<IGameHandlerService>();
        _commandExecutor = new Mock<ICommandExecutor>();
        _addGameHandler = new AddGameHandler(_commandExecutor.Object, _gameService.Object);
    }

    [Test]
    public async Task HandleShouldAddGame()
    {
        // Arrange
        var request = new AddGameRequest();
        var expectedGame = new Game();
        _gameService.Setup(gs => gs.GetGameToAddFromRequest(request)).Returns(Task.FromResult(expectedGame));

        // Act
        var result = await _addGameHandler.Handle(request, default);

        // Assert
        _gameService.Verify(gs => gs.GetGameToAddFromRequest(request), Times.Once);
        _commandExecutor.Verify(ce => ce.ExecuteCommand(It.Is<AddGameCommand>(c => c.Parameter == expectedGame)), Times.Once);
        if (result.Data != null)
        {
            Assert.That(result.Data, Is.EqualTo(request));
        }
    }
}