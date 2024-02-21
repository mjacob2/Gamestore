using Gamestore.DataAccess.Commands;

namespace Gamestore.DataAccess;

public interface ICommandExecutor
{
    Task<TResoult> ExecuteCommand<TParameters, TResoult>(CommandBase<TParameters, TResoult> command);
}
