using System;

namespace Bookshelf.Authorization.Exceptions
{
    public class LoginFailedException : Exception
    {
        public string Email { get; private set; }
        public LoginFailedException(string email)
        {
            Email = email;
        }

        public LoginFailedException() : base()
        {
        }

        public LoginFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
