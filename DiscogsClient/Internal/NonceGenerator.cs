using System;
using System.Text;

namespace DiscogsClient.Internal
{
    public static class NonceGenerator
    {
        private const int NonceLength = 32;
        private const string HexDigits = "0123456789abcdef";

        /// <summary>
        /// Creates the value sent as oauth_nonce with an OAuth 1.0a signed request.
        /// </summary>
        public static string Next()
        {
            var random = new Random();
            var builder = new StringBuilder(NonceLength);
            for (var i = 0; i < NonceLength; i++)
            {
                builder.Append(HexDigits[random.Next(HexDigits.Length)]);
            }
            return builder.ToString();
        }
    }
}
