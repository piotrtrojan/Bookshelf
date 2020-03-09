namespace Bookshelf.WebContract.Author.Response
{
    /// <summary>
    /// Response DTO containing single author.
    /// </summary>
    public class GetAuthorByIdResponse
    {
        /// <summary>
        /// Author's id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Author's first name. 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Author's last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Author's nationality id.
        /// </summary>
        public int NationalityId { get; set; }
    }
}
