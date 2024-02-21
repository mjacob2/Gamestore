using AutoMapper;
using Gamestore.ApplicationServices.Handlers.Games;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Queries.Games;
using Moq;

namespace Tests.HandlersTests.GamesHandlers;
[TestFixture]
public class GetAllGamesHandlerTests
{
    private Mock<IQueryExecutor> _queryExecutor;
    private Mock<IMapper> _mapper;
    private GetAllGamesHandler _getAllGamesHandler;

    [SetUp]
    public void SetUp()
    {
        _queryExecutor = new Mock<IQueryExecutor>();
        _mapper = new Mock<IMapper>();
        _getAllGamesHandler = new GetAllGamesHandler(_queryExecutor.Object, _mapper.Object);
    }

    [Test]
    public async Task HandleShouldReturnAllGames()
    {
        // Arrange
        var expectedGames = new List<GameListingModel> { new() };
        var databaseGames = new List<Game> { new() };
        _queryExecutor
            .Setup(x => x.ExecuteQuery(It.IsAny<GetAllGamesQuery>()))
            .ReturnsAsync(databaseGames);
        _mapper
            .Setup(x => x.Map<List<GameListingModel>>(databaseGames))
            .Returns(expectedGames);

        // Act
        var result = await _getAllGamesHandler.Handle(new GetAllGamesRequest(), default);

        // Assert
        _queryExecutor.Verify(x => x.ExecuteQuery(It.IsAny<GetAllGamesQuery>()), Times.Once);
        _mapper.Verify(x => x.Map<List<GameListingModel>>(databaseGames), Times.Once);
        Assert.That(result.Data, Is.EquivalentTo(expectedGames));
    }
}
