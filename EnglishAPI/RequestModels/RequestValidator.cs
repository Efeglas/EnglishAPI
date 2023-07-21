using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EnglishAPI.RequestModels
{
    public static class RequestValidator
    {   
        public static bool notEmpty(string value) { 
            return value != String.Empty;
        }

        public static bool longerThan(string value, int min) {
            return value.Length > min;
        }

        public static bool between(string value, int min, int max)
        {
            return value.Length > min && value.Length <= max;
        }

        public static bool containsNumber (string value)
        {
            return value.Any(c => char.IsNumber(c));
        }

        public static bool containsUppercase(string value)
        {
            return value.Any(c => char.IsUpper(c));         
        }

        public static bool password (string value)
        {
            return longerThan(value, 7) && containsNumber(value) && containsUppercase(value);
        }
    }
}
