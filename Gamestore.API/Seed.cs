using Gamestore.DataAccess;
using Gamestore.DataAccess.Entities;

namespace Gamestore.API;

internal class Seed
{
    private readonly GamestoreDbContext _databaseContext;

    public Seed(GamestoreDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task Run()
    {
        if (!_databaseContext.Genres.Any())
        {
            var strategy = new Genre
            {
                Name = "Strategy",
                SubGenres = new List<Genre>
                {
                new() { Name = "RTS" },
                new() { Name = "TBS" },
                },
            };
            var races = new Genre
            {
                Name = "Races",
                SubGenres = new List<Genre>
                {
                new() { Name = "Rally" },
                new() { Name = "Arcade" },
                new() { Name = "Formula" },
                new() { Name = "Off-road" },
                },
            };
            var action = new Genre
            {
                Name = "Action",
                SubGenres = new List<Genre>
                {
                new() { Name = "FPS" },
                new() { Name = "TPS" },
                },
            };
            var rpg = new Genre { Name = "RPG" };
            var sports = new Genre { Name = "Sports" };
            var adventure = new Genre { Name = "Adventure" };
            var puzzleAndSkill = new Genre { Name = "Puzzle & Skill" };
            var misc = new Genre { Name = "Misc" };

            await _databaseContext.Database.EnsureCreatedAsync();

            _databaseContext.Genres.AddRange(
                misc,
                puzzleAndSkill,
                adventure,
                sports,
                rpg,
                strategy,
                races,
                action);

            await _databaseContext.SaveChangesAsync();
        }
    }
}