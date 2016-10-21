using System.Linq;
using System.Collections.Generic;

namespace Accela.Apps.Core
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> AsEnumerableEmpty<T>(this IEnumerable<T> instance)
		{
			return instance == null ? Enumerable.Empty<T>() : instance.AsEnumerable();
		}

		public static bool HasValue<T>(this IEnumerable<T> instance)
		{
			return instance != null && instance.Any();
		}

		public static string Join<T>(this IEnumerable<T> instance, string separator = ",")
		{
			return string.Join(separator, instance);
		}

		public static bool MoreThanOne<T>(this IEnumerable<T> instance)
		{
			return instance != null && instance.Count() > 1;
		}
	}
}