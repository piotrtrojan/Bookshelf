namespace Bookshelf.Validator.Shared
{
    internal static class SharedValidationMessages
    {
        public static string PieceDoesNotExist => "Selected piece does not exists. ";
        
        public static string PieceNotAvailable => "Selected piece is not available. ";

        public static string InvalidNationality => "Invalid nationality. ";

        public static string AuthorNotFound => "Provided author does not exist. ";

        public static string InvalidOrderBy => "Given 'Order by' is invalid. Response type has no such field. ";

    }
}
