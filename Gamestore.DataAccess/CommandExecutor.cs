using Gamestore.DataAccess.Commands;

namespace Gamestore.DataAccess;

public class CommandExecutor : ICommandExecutor
{
    private readonly GamestoreDbContext _context;

    public CommandExecutor(GamestoreDbContext context)
    {
        _context = context;
    }

    public async Task<TResult> ExecuteCommand<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return await command.Execute(_context);
    }
}
