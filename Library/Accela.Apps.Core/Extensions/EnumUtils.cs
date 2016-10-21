using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace Accela.Apps.Core
{
	/// <summary>
	/// Class for retreiving extended enum info.
	/// 
	/// The example how enum can be configured is below.
	/// 
	/// [DefaultValue(SixMonths)]
	/// public enum ArchivingIntervalType
	/// {
	///     [Description("None")]
	///     None = 0,
	///
	///     [Description("1 month")]
	///     OneMonth = 1,
	///
	///     [Description("3 month")]
	///     ThreeMonths = 3,
	///}
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class EnumUtils<T>
	{
		#region Helper classes
		public class EnumDescriptor
		{
			public IDictionary<T, EnumItemDescriptor> Items { get; set; }

			public EnumItemDescriptor DefaultItem { get; set; }
		}

		public class EnumItemDescriptor
		{
			public EnumItemDescriptor()
			{
				Value = default(T);
				Name = String.Empty;
				Description = String.Empty;
			}

			public T Value { get; set; }

			public string Name { get; set; }

			public string Description { get; set; }

			public bool IsDefault { get; set; }

			public bool Selected { get { return IsDefault; } }

			public string Text { get { return Description; } }
		}

		internal class EnumItemDescriptorDescriptionComparer : IComparer<EnumItemDescriptor>
		{
			public int Compare(EnumItemDescriptor x, EnumItemDescriptor y)
			{
				return StringComparer.Ordinal.Compare(x.Description, y.Description);
			}
		}

		internal class EnumItemDescriptorNameComparer : IComparer<EnumItemDescriptor>
		{
			public int Compare(EnumItemDescriptor x, EnumItemDescriptor y)
			{
				return StringComparer.Ordinal.Compare(x.Name, y.Name);
			}
		}
		#endregion Helper classes

		static EnumUtils()
		{
			SetDefaultItem();
		}

		#region Singletone
		static private readonly object _syncRoot = new object();
		static private IDictionary<string, EnumDescriptor> _enumDescriptorsCache;

		static private IDictionary<string, EnumDescriptor> EnumDescriptorsCache
		{
			get
			{
				if (_enumDescriptorsCache == null)
				{
					lock (_syncRoot)
					{
						if (_enumDescriptorsCache == null)
						{
							_enumDescriptorsCache = new Dictionary<string, EnumDescriptor>();
						}
					}
				}
				return _enumDescriptorsCache;
			}
		}
		#endregion Singletone

		/// <summary>
		/// Get all descriptor values.
		/// </summary>
		/// <returns></returns>
		static public IEnumerable<EnumItemDescriptor> GetItems()
		{
			return Descriptors.Values;
		}

		/// <summary>
		/// Get all descriptor values sorted by description.
		/// </summary>
		/// <returns></returns>
		static public IEnumerable<EnumItemDescriptor> GetItemsSortedByDescription()
		{
			var descriptors = Descriptors.Values;
			var list = new List<EnumItemDescriptor>(descriptors);
			list.Sort(new EnumItemDescriptorDescriptionComparer());
			return list;
		}

		/// <summary>
		/// Get enum item index in list, sorted by name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		static public int GetIndexSortedByName(string name)
		{
			var list = GetItemsSortedByName().ToList();
			return list.IndexOf(list.SingleOrDefault(d => d.Name.ToLower() == name.ToLower()));
		}

		/// <summary>
		/// Get enum item index in list, sorted by name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		static public int GetIndexSortedByDescription(string description)
		{
			var list = GetItemsSortedByDescription().ToList();
			return list.IndexOf(list.SingleOrDefault(d => d.Description.ToLower() == description.ToLower()));
		}

		/// <summary>
		/// Get all descriptor values sorted by description.
		/// </summary>
		/// <returns></returns>
		static public IEnumerable<EnumItemDescriptor> GetItemsSortedByName()
		{
			var descriptors = Descriptors.Values;
			var list = new List<EnumItemDescriptor>(descriptors);
			list.Sort(new EnumItemDescriptorNameComparer());
			return list;
		}

		/// <summary>
		/// Get enum info.
		/// </summary>
		/// <returns>EnumDescriptor object.</returns>
		static public EnumDescriptor GetEnumInfo()
		{
			var enumType = typeof(T);
			string cacheKey = enumType.FullName;
			if (!EnumDescriptorsCache.ContainsKey(cacheKey))
			{
				var result = GetEnumInfoInternal();
				EnumDescriptorsCache[cacheKey] = result;
				return result;
			}
			return EnumDescriptorsCache[cacheKey];
		}

		/// <summary>
		/// Parse string value representation.
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		static public T Parse(string val)
		{
			return (T)Enum.Parse(typeof(T), val, true);
		}

		/// <summary>
		/// Return enum item by name
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
		public static EnumItemDescriptor GetItemByName(string itemName)
		{
			return GetItems().FirstOrDefault(i => i.Name == itemName);
		}

		/// <summary>
		/// Return enum item value by name
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
		public static T GetValueByName(string itemName)
		{
			return GetItems().FirstOrDefault(i => i.Name == itemName).Value;
		}

		/// <summary>
		/// Get enum item description by value
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
		public static string GetDescriptionByValue(T value)
		{
			var enumDescriptor = Descriptors[value];
			return enumDescriptor == null ? String.Empty : enumDescriptor.Description;
		}

		/// <summary>
		/// Get enum item description by value
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
		public static T GetValueByDescription(string description)
		{
			try
			{
				return Descriptors.Values.SingleOrDefault(d => d.Description == description).Value;
			}
			catch (Exception)
			{
				throw new ApplicationException("Can`t get value by description '{0}' for enum {1}".FormatWith(description, typeof(T).Name));
			}
		}

		public static bool Equals(object value, T valueToCompare)
		{
			return Enum.ToObject(typeof (T), value).Equals(valueToCompare);
		}

		#region Private
		static private EnumDescriptor GetEnumInfoInternal()
		{
			var result = new EnumDescriptor();
			result.Items = Descriptors;
			result.DefaultItem = Descriptors[_defaultItem];
			return result;
		}

		static private IDictionary<T, EnumItemDescriptor> Descriptors
		{
			get
			{
				if (_descriptors == null)
				{
					var enumType = typeof(T);
					var infos = enumType.GetFields();
					infos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

					var result = new Dictionary<T, EnumItemDescriptor>();
					foreach (var fi in infos)
					{
						var descr = new EnumItemDescriptor();
						descr.Value = (T)(fi.GetRawConstantValue());
						descr.Name = fi.Name;
						descr.Description = GetDescription(fi);
						descr.IsDefault = descr.Value.Equals(_defaultItem);
						result.Add(descr.Value, descr);
					}

					_descriptors = result;
				}
				if (_descriptors.Count == 0)
				{
					throw new ApplicationException("The enum is empty and can`t be used with utility class.");
				}
				return _descriptors;
			}
		}

		static private string GetDescription(FieldInfo fi)
		{
			object[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes != null && attributes.Length > 0)
			{
				var attr = attributes[0] as DescriptionAttribute;
				if (attr != null)
				{
					return attr.Description;
				}
			}
			return String.Empty;
		}

		static private void SetDefaultItem()
		{
			var enumType = typeof(T);
			var attributes = enumType.GetCustomAttributes(typeof(DefaultValueAttribute), false);
			if (attributes != null && attributes.Length > 0)
			{
				var attribute = (DefaultValueAttribute)attributes[0];
				var attrValue = (T)(attribute.Value);
				_defaultItem = attrValue;
			}
			else
			{
				_defaultItem = Descriptors.First().Value.Value;
			}
		}

		static private T _defaultItem = default(T);
		static private IDictionary<T, EnumItemDescriptor> _descriptors;
		#endregion Private
	}
}
