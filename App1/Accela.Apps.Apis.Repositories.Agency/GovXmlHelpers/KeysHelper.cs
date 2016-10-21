using System;
using System.Linq;
using System.Text.RegularExpressions;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// the class is used to process key convert
    /// </summary>
    public static class KeysHelper  
    {
        /// <summary>
        /// convert govxml keys to StringKeys
        /// </summary>
        /// <param name="XMLKeys">The XML keys.</param>
        /// <returns>a string key with separator</returns>
        public static string ToStringKeys(this Keys XMLKeys)
        {
            return CreateStringKeys(XMLKeys);
        }

        /// <summary>
        /// Contacts the specified current keys.
        /// </summary>
        /// <param name="currentKeys">The current keys.</param>
        /// <param name="otherKeys">The other keys.</param>
        /// <returns>the specified current keys.</returns>
        public static Keys Contact(this Keys currentKeys, Keys otherKeys)
        {
            Keys result = null;

            if (currentKeys != null && currentKeys.key != null && otherKeys != null && otherKeys.key != null)
            {
                result = new Keys();
                result.key = currentKeys.key.Concat(otherKeys.key).ToArray();
            }
            else
            {
                result = currentKeys;
            }

            return result;
        }

        /// <summary>
        /// Contacts the specified current keys.
        /// </summary>
        /// <param name="currentKeys">The current keys.</param>
        /// <param name="otherKeys">The other keys.</param>
        /// <returns>the specified current keys.</returns>
        public static string Contact(string currentIdentifier, string otherIdentifier)
        {
            Keys currentKeys = CreateXMLKeys(currentIdentifier);
            Keys otherKeys = CreateXMLKeys(otherIdentifier);
            Keys newKeys = currentKeys.Contact(otherKeys);
            return ToStringKeys(newKeys);
        }

        /// <summary>
        /// CreateXMLKeys
        /// </summary>
        /// <param name="stringKeys">The string keys.</param>
        /// <returns>Gov XML key</returns>
        public static Keys CreateXMLKeys(string stringKeys)
        {
            Keys xmlKeys = null;
            if (stringKeys != null)
            {
                xmlKeys = new Keys();
                DecopKeys(xmlKeys, stringKeys);
            }

            return xmlKeys;
        }

        private static void DecopKeys(Keys xmlKeys, string stringKeys)
        {
            string[] strKeys = Regex.Split(stringKeys, "-");
            for (int i = 0; i < strKeys.Length; i++)
            {
                strKeys[i] = IdEscapeHelper.DecodeString(strKeys[i]);
            }

            xmlKeys.key = strKeys;
        }

        /// <summary>
        /// CreateStringKeys
        /// </summary>
        /// <param name="XMLKeys">The XML keys.</param>
        /// <returns>a string key with separator</returns>
        private static string CreateStringKeys(Keys XMLKeys)
        {
            string retuVal = String.Empty;

            if (XMLKeys != null 
                && XMLKeys.key != null
                && XMLKeys.key.Length > 0)
            {
                retuVal = IdEscapeHelper.EncodeString(XMLKeys.key[0]);
                for (int i = 1; i < XMLKeys.key.Length; i++)
                {
                    retuVal += "-";
                    retuVal += IdEscapeHelper.EncodeString(XMLKeys.key[i]);
                }
            }

            return retuVal;
        }

 
    }
}
