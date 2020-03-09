namespace Bookshelf.WebContract.BookTag.Response
{
    /// <summary>
    /// Response DTO containing tag name and it's id.
    /// </summary>
    public class BookTagResponse
    {
        /// <summary>
        /// Tag id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tag value (text).
        /// </summary>
        public string Tag { get; set; }
    }
}
