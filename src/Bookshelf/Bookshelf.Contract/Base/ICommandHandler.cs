namespace Bookshelf.Contract.Base
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
    }
}
