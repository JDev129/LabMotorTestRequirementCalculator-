using System.Text.RegularExpressions;

namespace Commons
{
    public static class StringExtensions
    {
        public static bool IsIntegerAndGreaterThanZero(
            this string attempt) =>
            (int.TryParse(attempt, out int res) && res > 0);

        public static string[] NumbersSplitOnDashes(
            this string attempt) =>
            Regex.Match(attempt, @"^[0-9-]*$").ToString().Split('-');

        public static string[] NumbersSplitOnForwardSlash(
            this string attempt) =>
            Regex.Match(attempt, @"^[0-9/ -]+$").ToString().Split('/');

        public static string NewLine(
            this string @this) => @this + "\r\n";

        public static string AddNumberOfSpaces(
            this string @this, 
            int number)
        {
            for (int i = 0; i < number; i++)
                @this = @this.AddOneSpace();
            return @this;
        }

        public static string AddOneSpace(
            this string @this) => @this + " ";

        public static string CombineIntoSingleQuoteCSV(
            this string[] @this)
        {
            var retval = string.Empty;
            for (int i = 0; i < @this.Length; i++)
                retval += ((i > 0) ? ",": "") +"'"+ @this[i] + "' ";
            return retval;
        }

    }
}
