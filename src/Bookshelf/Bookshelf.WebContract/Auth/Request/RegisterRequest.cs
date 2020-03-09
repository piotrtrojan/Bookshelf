namespace Bookshelf.WebContract.Auth.Request
{
    /// <summary>
    /// DTO for registering new user.
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
        
        /// <summary>
        /// New user nationality
        /// </summary>
        public string Nationality { get; set; }
    }
}
