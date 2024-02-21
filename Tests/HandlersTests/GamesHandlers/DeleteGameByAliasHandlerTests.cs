using Gamestore.ApplicationServices.Handlers.Games;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using Gamestore.DataAccess.Entities;
using Moq;

namespace Tests.HandlersTests.GamesHandlers;
[TestFixture]
public class DeleteGameByAliasHandlerTests
{
    private Mock<ICommandExecutor> _commandExecutor;
    private DeleteGameByAliasHandler _deleteGameHandler;

    [SetUp]
    public void SetUp()
    {
        _commandExecutor = new Mock<ICommandExecutor>();
        _deleteGameHandler = new DeleteGameByAliasHandler(_commandExecutor.Object);
    }

    [Test]
    public async Task HandleShouldDeleteGameByAlias()
    {
        // Arrange
        var request = new DeleteGameRequest { GameAlias = "Test-alias" };
        var game = new Game { GameAlias = "Test-alias" };
        var response = new DeleteGameResponse { Data = request };

        _commandExecutor.Setup(m => m.ExecuteCommand(It.IsAny<DeleteGameCommand>())).ReturnsAsync(game);

        // Act
        var result = await _deleteGameHandler.Handle(request, default);

        // Assert
        _commandExecutor.Verify(m => m.ExecuteCommand(It.IsAny<DeleteGameCommand>()), Times.Once);
        Assert.That(response.Data.GameAlias, Is.EqualTo(result.Data.GameAlias));
    }
}
