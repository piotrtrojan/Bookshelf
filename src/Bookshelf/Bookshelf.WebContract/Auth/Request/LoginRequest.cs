using System.ComponentModel.DataAnnotations;

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
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
