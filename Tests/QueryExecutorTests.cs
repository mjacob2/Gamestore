using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using NotFoundException = Gamestore.DataAccess.Exceptions.NotFoundException;

namespace Tests;
[TestFixture]
public class QueryExecutorTests
{
    private Mock<GamestoreDbContext> _mockContext;
    private QueryExecutor _queryExecutor;

    [SetUp]
    public void SetUp()
    {
        _mockContext = new Mock<GamestoreDbContext>(new DbContextOptions<GamestoreDbContext>());
        _queryExecutor = new QueryExecutor(_mockContext.Object);
    }

    [Test]
    public void ExecuteQueryWhenResultIsNullThrowsNotFoundException()
    {
        // Arrange
        var query = new Mock<QueryBase<string>>();
        query.Setup(q => q.Execute(_mockContext.Object)).Returns(Task.FromResult<string>(null));

        // Assert
        Assert.ThrowsAsync<NotFoundException>(async () => await _queryExecutor.ExecuteQuery(query.Object));
    }

    [Test]
    public async Task ExecuteQueryWhenResultIsNotNullReturnsResult()
    {
        // Arrange
        var expectedResult = "Test Result";
        var query = new Mock<QueryBase<string>>();
        query.Setup(q => q.Execute(_mockContext.Object)).ReturnsAsync(expectedResult);

        // ACT
        var result = await _queryExecutor.ExecuteQuery(query.Object);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
