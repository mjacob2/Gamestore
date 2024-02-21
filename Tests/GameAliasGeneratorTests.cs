namespace Tests;

[TestFixture]
public class GameAliasGeneratorTests
{
    private GameAliasService _aliasService;

    [SetUp]
    public void Setup()
    {
        _aliasService = new GameAliasService();
    }

    [Test]
    public void GenerateAliasGeneratesAliasFromNameWhenNoAliasProvided()
    {
        // Arrange
        var name = "My Name";

        // Act
        var result = _aliasService.GenerateAlias(name);

        // Assert
        Assert.That(result, Is.EqualTo("my-name"));
    }

    [TestCase("Crysis 2", "crysis-2")]
    [TestCase("Portal", "portal")]
    [TestCase("Half-Life", "half-life")]
    [TestCase("The Witcher 3: Wild Hunt", "the-witcher-3-wild-hunt")]
    public void ShouldGenerateCorrectAliasFromName(string name, string expected)
    {
        // Act
        var result = _aliasService.GenerateAliasFromName(name);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GenerateAliasFromNameEmptyInputThrowsException()
    {
        // Arrange
        string nameFromRequest = string.Empty;

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => _aliasService.GenerateAliasFromName(nameFromRequest));

        Assert.That(ex.ParamName, Is.EqualTo("name"));
    }
}