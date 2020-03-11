using Bookshelf.Application.Nationality.Query;
using Bookshelf.Contract.Base;
using Bookshelf.Validator.Shared.Interfaces;

namespace Bookshelf.Validator.Shared
{
    internal class NationalityValidator : INationalityValidator
    {
        private readonly IQueryHandler<GetNationalityIdByNameQuery, int?> getNationalityIdByNameQueryHandler;

        public NationalityValidator(IQueryHandler<GetNationalityIdByNameQuery, int?> getNationalityIdByNameQueryHandler)
        {
            this.getNationalityIdByNameQueryHandler = getNationalityIdByNameQueryHandler;
        }
        public bool ValidateNationality(string nationality)
        {
            if (string.IsNullOrEmpty(nationality))
                return false;
            return getNationalityIdByNameQueryHandler.Handle(new GetNationalityIdByNameQuery { Name = nationality }).HasValue;
        }
    }
}
