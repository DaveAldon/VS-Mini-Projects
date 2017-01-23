//David Crawford CIS 443 HWK 1
//Validation class
using System;

namespace WindowsFormsApplication1
{
    class validation
    {
        /// <summary>
        /// Checks if the string is empty
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool isPresent(string field)
        {
            if (field == string.Empty) return false;
            else return true;
        }

        /// <summary>
        /// Checks if the string can be converted into a decimal
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool isDecimal(string field)
        {
            decimal returnNumber;
            bool isDec = Decimal.TryParse(field, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out returnNumber);
            return isDec;
        }

        /// <summary>
        /// Checks if the string can be converted into an integer
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool isInt(string field)
        {
            int returnNumber;
            bool isDec = int.TryParse(field, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out returnNumber);
            return isDec;
        }

        /// <summary>
        /// Checks that a number is between two values
        /// </summary>
        /// <param name="field"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public bool isWithinRange(int field, int low, int high)
        {
            if ((field < low) || (field > high)) return false;
            else return true;
        }

        /// <summary>
        /// Checks if a provided number is above a given value
        /// </summary>
        /// <param name="field"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        public bool isAboveValue(decimal field, int low)
        {
            if (field < low) return false;
            else return true;
        }

        //From http://stackoverflow.com/questions/7348768/the-given-paths-format-is-not-supported#7348799
        /// <summary>
        /// Checks a string to remove characters that are unsafe for file names
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string toSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
    }
}
