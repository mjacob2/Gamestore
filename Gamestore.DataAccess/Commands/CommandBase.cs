namespace Gamestore.DataAccess.Commands;

public abstract class CommandBase<TParameter, TResoult>
{
    public TParameter Parameter { get; set; }

    public abstract Task<TResoult> Execute(GamestoreDbContext context);
}
