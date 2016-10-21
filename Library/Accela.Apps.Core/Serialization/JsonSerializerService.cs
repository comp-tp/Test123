using Accela.Core.Ioc;

namespace Accela.Core.Serialization
{
	public static class JsonSerializerService
	{
		public static IJsonSerializer Current { get; set; }

		static JsonSerializerService()
		{
			Current = IocContainer.Resolve<IJsonSerializer>();
		}

		public static T Deserialize<T>(string value)
		{
			return (T) Current.Deserialize(value, typeof (T));
		}
	}
}