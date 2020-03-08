using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils;

namespace Bookshelf.Application.Author.CommandHandler
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
    {
        private readonly string _connectionString;
        private readonly IMapper mapper;

        public CreateAuthorCommandHandler(
            GlobalConfig globalConfig,
            IMapper mapper)
        {
            _connectionString = globalConfig.CommandConnectionString;
            this.mapper = mapper;
        }
        public CommandResult Handle(CreateAuthorCommand command)
        {
            var author = mapper.Map<Model.Entity.Author>(command);
            using (var ctx = new BookshelfDbContext(_connectionString))
            {
                ctx.Authors.Add(author);
                ctx.SaveChanges();
                return CommandResult.Ok(author.Id);
            }
        }
    }
}
