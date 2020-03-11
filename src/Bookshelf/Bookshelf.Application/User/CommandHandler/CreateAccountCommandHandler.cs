using Bookshelf.Application.User.Command;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils.Config;
using System;

namespace Bookshelf.Application.User.CommandHandler
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly string connectionString;

        public CreateAccountCommandHandler(GlobalConfig globalConfig)
        {
            this.connectionString = globalConfig.CommandConnectionString;
        }
        public CommandResult Handle(CreateAccountCommand command)
        {
            using (var ctx = new BookshelfDbContext(connectionString))
            {
                var user = new Model.Entity.User
                {
                    AspNetGuid = command.AspNetGuid,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    CardId = new Random().Next(1, 99999999), // TODO: In the future check if number is not used yet.
                };
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return CommandResult.Ok(user.Id);
            }
        }
    }
}
