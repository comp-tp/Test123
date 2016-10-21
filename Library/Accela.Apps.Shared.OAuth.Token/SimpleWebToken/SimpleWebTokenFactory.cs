using Accela.Apps.Shared.Encryptions;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Accela.Apps.Shared.OAuth.Token
{
    public class SimpleWebTokenFactory
    {
        private const string KEY_HMACSHA256 = "HMACSHA256";

        public static string CreateToken(SimpleWebTokenModel model, string signingKey, string encryptionKey)
        {
            if (model == null)
            {
                throw new Exception("No SimpleWebTokenModel data.");
            }

            if (String.IsNullOrWhiteSpace(signingKey))
            {
                throw new Exception("Signing key should be empty.");
            }

            var allKeyValuePairs = model.GetAllKeyValuePairs();
            var unsignedToken = BuildQueryString(allKeyValuePairs);
            string signature = GenerateSignature(unsignedToken, signingKey);
            allKeyValuePairs.Add(KEY_HMACSHA256, signature);
            var signedToken = BuildQueryString(allKeyValuePairs);
            var encryptedToken = EncryptToken(signedToken, encryptionKey);

            return encryptedToken;
        }

        public static SimpleWebTokenModel ParseAndValidateToken(string token, string signingKey, string encryptionKey)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                throw new TokenException("Token is invalid.", String.Empty, ErrorCodes.no_token_401);
            }

            if (String.IsNullOrWhiteSpace(signingKey))
            {
                throw new MobileException("Signing key should not be empty.");
            }

            var rawToken = DecryptToken(token, encryptionKey);

            var items = HttpUtility.ParseQueryString(rawToken);
            var passedSignture = items[KEY_HMACSHA256];
            items.Remove(KEY_HMACSHA256);
            var unsignedToken = items.ToString();
            var result = SimpleWebTokenModel.Parse(items);

            string computedSignature = GenerateSignature(unsignedToken, signingKey);

            if (String.IsNullOrWhiteSpace(passedSignture) || !passedSignture.Equals(computedSignature, StringComparison.Ordinal))
            {
                throw new TokenException("Signature is invalid.", String.Empty, ErrorCodes.invalid_token_401);
            }

            if (result.IsExpired())
            {
                throw new TokenException("Token has expired.", String.Empty, ErrorCodes.token_expired_401);
            }

            return result;
        }

        private static string BuildQueryString(NameValueCollection keyValuePairs, bool toBeUrlEncoded = true)
        {
            if (keyValuePairs == null || keyValuePairs.Count == 0)
            {
                return String.Empty;
            }

            StringBuilder content = new StringBuilder();

            foreach (var key in keyValuePairs.AllKeys)
            {
                var value = keyValuePairs[key];

                if (String.IsNullOrWhiteSpace(key) || String.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                if (toBeUrlEncoded)
                {
                    value = HttpUtility.UrlEncode(value);
                }

                if (content.Length > 0)
                {
                    content.Append("&");
                }

                content.Append(key).Append("=").Append(value);
            }

            var result = content.ToString();
            return result;
        }

        private static string GenerateSignature(string unsignedToken, string signingKey)
        {
            byte[] signingKeyUnsignedValues = null;
            try
            {
                signingKeyUnsignedValues = Convert.FromBase64String(signingKey);
            }
            catch
            {
                throw new MobileException("Invalid signing key.");
            }

            var hmac = new HMACSHA256(signingKeyUnsignedValues);

            byte[] locallyGeneratedSignatureInBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(unsignedToken));

            string locallyGeneratedSignature = Convert.ToBase64String(locallyGeneratedSignatureInBytes);

            return locallyGeneratedSignature;
        }

        private static string EncryptToken(string token, string encryptionKey)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                return String.Empty;
            }

            var encryptedTokenBytes = AESHelper.Encrypt(token, encryptionKey);
            var result = HttpServerUtility.UrlTokenEncode(encryptedTokenBytes);

            return result;
        }

        private static string DecryptToken(string token, string encryptionKey)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                return String.Empty;
            }

            var tokenBytes = HttpServerUtility.UrlTokenDecode(token);
            var result = AESHelper.Decrypt(tokenBytes, encryptionKey);

            return result;
        }
    }
}
