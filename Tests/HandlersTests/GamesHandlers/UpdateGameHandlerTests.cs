using Gamestore.ApplicationServices.Handlers.Games;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Services.GameHandlerService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using Gamestore.DataAccess.Entities;
using Moq;

namespace Tests.HandlersTests.GamesHandlers;
[TestFixture]
public class UpdateGameHandlerTests
{
    private Mock<ICommandExecutor> _commandExecutor;
    private UpdateGameHandler _updateGameHandler;
    private Mock<IGameHandlerService> _gameService;

    [SetUp]
    public void SetUp()
    {
        _commandExecutor = new Mock<ICommandExecutor>();
        _gameService = new Mock<IGameHandlerService>();
        _updateGameHandler = new UpdateGameHandler(_commandExecutor.Object, _gameService.Object);
    }

    [Test]
    public async Task HandleShouldUpdateGame()
    {
        // Arrange
        var request = new UpdateGameRequest();
        var expectedGame = new Game();
        _gameService.Setup(gs => gs.GetGameToUpdateFromRequest(request)).Returns(Task.FromResult(expectedGame));

        // Act
        var result = await _updateGameHandler.Handle(request, default);

        // Assert
        _gameService.Verify(gs => gs.GetGameToUpdateFromRequest(request), Times.Once);
        _commandExecutor.Verify(ce => ce.ExecuteCommand(It.Is<UpdateGameCommand>(c => c.Parameter == expectedGame)), Times.Once);
        if (result.Data != null)
        {
            Assert.That(result.Data, Is.EqualTo(request));
        }
    }
}
