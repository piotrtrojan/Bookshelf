using AutoMapper;
using Bookshelf.Application.Author.Command;
using Bookshelf.Application.Book.Command;
using Bookshelf.Application.Book.Query;
using Bookshelf.Application.User.Command;
using Bookshelf.WebContract.Auth.Request;
using Bookshelf.WebContract.Author.Request;
using Bookshelf.WebContract.Book.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Application
{
    public static class RegisterAutoMapper
    {
        public static void RegisterApplicationAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(new[] { typeof(ApplicationAutomapperProfile) });
        }
    }

    public class ApplicationAutomapperProfile : Profile
    {
        public ApplicationAutomapperProfile()
        {
            RegisterAuth();
            RegisterAuthor();
            RegisterBook();
        }

        private void RegisterBook()
        {
            CreateMap<CreateBookRequest, CreateBookCommand>();
            CreateMap<CreateBookCommand, Model.Entity.Book>()
                .ForMember(q => q.BookTags, opt => opt.Ignore());
            CreateMap<GetBooksByAuthorRequest, GetBooksByAuthorQuery>();
        }

        private void RegisterAuthor()
        {
            CreateMap<CreateAuthorRequest, CreateAuthorCommand>();
            CreateMap<CreateAuthorCommand, Model.Entity.Author>()
                .ForMember(q => q.Nationality, opt => opt.Ignore());
        }

        private void RegisterAuth()
        {
            CreateMap<RegisterRequest, CreateAccountCommand>();
        }
    }
}
