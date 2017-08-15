using System;
using System.Collections;
namespace Wilddog.Sms.Util
{
    public class ValidationUtils
    {
        /// <summary>
        /// Nots the empty string.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        public static void NotEmptyString(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException($"{argumentName} can not be null or empty.");
            }
        }

        /// <summary>
        /// Nots the empty collection.
        /// </summary>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
		public static void NotEmptyCollection(ICollection argument, string argumentName)
        {
            if (argument is null || argument.Count == 0)
            {
                throw new ArgumentException($"{argumentName} can not be null or empty.");
            }
        }
    }
}
