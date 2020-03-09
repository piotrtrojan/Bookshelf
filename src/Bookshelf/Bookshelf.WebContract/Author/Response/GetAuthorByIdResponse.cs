namespace Bookshelf.WebContract.Author.Response
{
    public class GetAuthorByIdResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalityId { get; set; }
    }
}
