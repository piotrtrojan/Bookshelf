namespace Bookshelf.WebContract.Author.Request
{
    /// <summary>
    /// DTO for creating new Author
    /// </summary>
    public class CreateAuthorRequest
    {
        /// <summary>
        /// New author first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// New author last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// New author nationality.
        /// </summary>
        public string Nationality { get; set; }
    }
}
