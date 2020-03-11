
using AutoMapper;
using Bookshelf.Application.Book.Command;
using Bookshelf.Contract.Base;
using Bookshelf.Repository.Context;
using Bookshelf.Utils.Config;
using System.Collections.Generic;

namespace Bookshelf.Application.Book.CommandHandler
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        private readonly string _connectionString;
        private readonly IMapper mapper;

        public CreateBookCommandHandler(
            GlobalConfig globalConfig,
            IMapper mapper)
        {
            _connectionString = globalConfig.CommandConnectionString;
            this.mapper = mapper;
        }

        public CommandResult Handle(CreateBookCommand command)
        {
            var book = mapper.Map<Model.Entity.Book>(command);
            book.BookTags = new List<Model.Entity.BookTag>();
            foreach (var tag in command.BookTags)
            {
                book.BookTags.Add(new Model.Entity.BookTag
                {
                    Tag = tag
                });
            }

            using (var ctx = new BookshelfDbContext(_connectionString))
            {
                ctx.Books.Add(book);
                ctx.SaveChanges();
                return CommandResult.Ok(book.Id);
            }
        }
    }
}


