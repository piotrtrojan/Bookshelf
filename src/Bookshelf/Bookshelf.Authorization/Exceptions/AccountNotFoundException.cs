using System;

namespace Bookshelf.Authorization.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public string Email { get; private set; }
        public AccountNotFoundException(string email) : base()
        {
            Email = email;
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AccountNotFoundException()
        {
        }
    }
}
