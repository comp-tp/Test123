using System;
using System.Globalization;

namespace Accela.Apps.Core.Extensions
{
	public static class IntExtensions
	{
		public static string GetString(this int? value)
		{
			return value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : String.Empty;
		}
	}
}
