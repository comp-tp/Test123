using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace Accela.Apps.Core
{
	public static class StringExtensions
	{
		private static readonly Regex IsNumericRegex = new Regex(@"[.,\-0-9]+", RegexOptions.Compiled);

		private static readonly Regex IsBase64StringRegex = new Regex(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.Compiled);

		public static bool IsNullOrEmpty(this string instance)
		{
			return IsNullOrEmpty(instance, true);
		}

		public static bool IsNullOrEmpty(this string instance, bool trim)
		{
			return string.IsNullOrEmpty(instance) || string.IsNullOrEmpty(instance.Trim());
		}

		public static bool IsNotNullOrEmpty(this string instance)
		{
			return IsNotNullOrEmpty(instance, true);
		}

		public static bool HasValue(this string instance)
		{
			return IsNotNullOrEmpty(instance, true);
		}

		public static string GetValue(this string instance)
		{
			return instance.HasValue() ? instance : String.Empty;
		}

		public static bool IsNotNullOrEmpty(this string instance, bool trim)
		{
			return !IsNullOrEmpty(instance, trim);
		}

		public static string FormatWith(this string instance, params object[] args)
		{
			return string.Format(instance, args);
		}

		public static bool IsNumeric(this string instance)
		{
			return IsNumericRegex.IsMatch(instance);
		}

		public static bool IsBase64String(this string instance)
		{
			instance = instance.Trim();
			return (instance.Length%4 == 0) && IsBase64StringRegex.IsMatch(instance);
		}

		public static XmlDocument ToXmlDocument(this string instance)
		{
			if (instance.HasValue())
			{
				var doc = new XmlDocument();
				doc.LoadXml(instance);
				return doc;
			}
			return null;
		}


        //todo: may be have this extension to base type i.e. "object".
        public static T ConvertTo<T>(this string sourceValue)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, sourceValue);
        }
	}
}