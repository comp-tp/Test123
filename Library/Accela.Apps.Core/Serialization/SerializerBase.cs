using System;
using System.IO;
using System.Text;

namespace Accela.Core.Serialization
{
	public abstract class SerializerBase : ISerializer
	{
		public string Serialize(object obj, Type objType = null, SerializerSettings settings = null)
		{
			if (obj == null) return null;

			string serialized;
			if (objType == null) objType = obj.GetType();
			using (var stream = new MemoryStream())
			{
				Serialize(stream, obj, objType, settings);
				stream.Seek(0, SeekOrigin.Begin);

				if (IsBinary)
				{
					var bytes = stream.GetBuffer();
					serialized = Convert.ToBase64String(bytes);
				}
				else
				{
					using (var reader = new StreamReader(stream))
					{
						serialized = reader.ReadToEnd();
					}
				}
			}
			return serialized;
		}

		public abstract void Serialize(Stream stream, object obj, Type objType = null, SerializerSettings settings = null);

		public object Deserialize(string serializedStr, Type objType, SerializerSettings settings = null)
		{
			if (string.IsNullOrEmpty(serializedStr) == false)
			{
				if (IsBinary)
				{
					var bytes = Convert.FromBase64String(serializedStr);
					using (var stream = new MemoryStream(bytes))
					{
						return Deserialize(stream, objType, settings);
					}
				}
				using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(serializedStr)))
				{
					return Deserialize(stream, objType, settings);
				}
			}
			return null;
		}

		public abstract object Deserialize(Stream stream, Type objType, SerializerSettings settings = null);

		public T Deserialize<T>(string serializedStr, SerializerSettings settings)
		{
			return (T) Deserialize(serializedStr, typeof (T), settings);
		}

		public T Deserialize<T>(Stream stream, SerializerSettings settings)
		{
			return (T) Deserialize(stream, typeof (T), settings);
		}

		public abstract bool IsBinary { get; }
	}
}