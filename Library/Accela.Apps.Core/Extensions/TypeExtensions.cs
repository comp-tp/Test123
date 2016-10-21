using System;

namespace Accela.Apps.Core
{
	public static class TypeExtensions
	{
		public static bool IsAssignableTo(this Type sourceType, Type targetType)
		{
			return targetType.IsAssignableFrom(sourceType);
		}

		public static bool IsNullable(this Type type)
		{
			return type == typeof (string) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>));
		}

		public static object DefaultValue(this Type type)
		{
			return (type.IsValueType && !type.IsNullable()) ? Activator.CreateInstance(type) : null;
		}
	}
}