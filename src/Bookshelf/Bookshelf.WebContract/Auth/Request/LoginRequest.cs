namespace Bookshelf.WebContract.Auth.Request
{
    /// <summary>
    /// Request for login (new token request).
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
