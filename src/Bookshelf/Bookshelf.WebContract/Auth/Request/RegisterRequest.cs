namespace Bookshelf.WebContract.Auth.Request
{
    /// <summary>
    /// Request for registering new user.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// New user email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// New user password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// New user first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// New user last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
