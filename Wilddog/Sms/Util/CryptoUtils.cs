using System;
using System.Security.Cryptography;
using System.Text;
namespace Wilddog.Sms.Util
{
    public class CryptoUtils
    {
        /// <summary>
        /// Sha256 the specified text.
        /// </summary>
        /// <returns>The sha256.</returns>
        /// <param name="text">Text.</param>
		public static string Sha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += $"{x:x2}";
            }
            return hashString;
        }
    }

}
