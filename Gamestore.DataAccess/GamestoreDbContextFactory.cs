using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gamestore.DataAccess;

public class GamestoreDbContextFactory : IDesignTimeDbContextFactory<GamestoreDbContext>
{
    public GamestoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GamestoreDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Gamestore;Trusted_Connection=True;");
        return new GamestoreDbContext(optionsBuilder.Options);
    }
}
