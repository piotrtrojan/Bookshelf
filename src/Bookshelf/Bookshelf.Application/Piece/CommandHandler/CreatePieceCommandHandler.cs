using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Application.Nationality.Query;
using Bookshelf.Application.Piece.Command;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils.Config;

namespace Bookshelf.Application.Piece.CommandHandler
{
    public class CreatePieceCommandHandler : ICommandHandler<CreatePieceCommand>
    {
        private readonly string _connectionString;
        private readonly IMapper mapper;
        
        public CreatePieceCommandHandler(
            GlobalConfig globalConfig,
            IMapper mapper)
        {
            _connectionString = globalConfig.CommandConnectionString;
            this.mapper = mapper;
        }
        public CommandResult Handle(CreatePieceCommand command)
        {
            var piece = mapper.Map<Model.Entity.Piece>(command);
            using (var ctx = new BookshelfDbContext(_connectionString))
            {
                ctx.Pieces.Add(piece);
                ctx.SaveChanges();
                return CommandResult.Ok(piece.Id);
            }
        }
    }
}
