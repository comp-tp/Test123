using System.Collections.Generic;

namespace Accela.Apps.Core
{
	public static class DictionaryExtensions
	{
		public static IDictionary<K, V> Set<K, V>(this IDictionary<K, V> instance, K key, V value)
		{
			instance[key] = value;
			return instance;
		}
	}
}