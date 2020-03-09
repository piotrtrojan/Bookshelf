namespace Bookshelf.WebContract.Auth.Request
{
    /// <summary>
    /// DTO for login request (new token request).
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }
    }
}
