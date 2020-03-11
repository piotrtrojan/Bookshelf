using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Application.Nationality.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils.Config;

namespace Bookshelf.Application.Author.CommandHandler
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
    {
        private readonly string _connectionString;
        private readonly IMapper mapper;
        private readonly IQueryHandler<GetNationalityIdByNameQuery, int?> getNationalityIdByNameQueryHandler;

        public CreateAuthorCommandHandler(
            GlobalConfig globalConfig,
            IMapper mapper,
            IQueryHandler<GetNationalityIdByNameQuery, int?> getNationalityIdByNameQueryHandler)
        {
            _connectionString = globalConfig.CommandConnectionString;
            this.mapper = mapper;
            this.getNationalityIdByNameQueryHandler = getNationalityIdByNameQueryHandler;
        }
        public CommandResult Handle(CreateAuthorCommand command)
        {
            var author = mapper.Map<Model.Entity.Author>(command);
            var nationalityId = getNationalityIdByNameQueryHandler.Handle(new GetNationalityIdByNameQuery { Name = command.Nationality });
            author.NationalityId = nationalityId.Value;
            using (var ctx = new BookshelfDbContext(_connectionString))
            {
                ctx.Authors.Add(author);
                ctx.SaveChanges();
                return CommandResult.Ok(author.Id);
            }
        }
    }
}
