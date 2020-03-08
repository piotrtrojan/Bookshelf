using System;

namespace Bookshelf.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str) => string.IsNullOrEmpty(str) || str.Length < 2 ? str : Char.ToLowerInvariant(str[0]) + str.Substring(1);
        public static string ToTitleCase(this string str) => string.IsNullOrEmpty(str) || str.Length < 2 ? str : Char.ToUpperInvariant(str[0]) + str.Substring(1);
    }
}
