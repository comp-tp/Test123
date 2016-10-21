using System;
using System.IO;

namespace Accela.Core.Serialization
{
    public interface ISerializer
    {
        string Serialize(object obj, Type objType = null, SerializerSettings settings = null);
        void Serialize(Stream stream, object obj, Type objType = null, SerializerSettings settings = null);
        object Deserialize(string serializedStr, Type objType, SerializerSettings settings = null);
        object Deserialize(Stream stream, Type objType, SerializerSettings settings = null);
        T Deserialize<T>(string serializedStr, SerializerSettings settings = null);
        T Deserialize<T>(Stream stream, SerializerSettings settings = null);
        bool IsBinary { get; }
    }

    #region IJsonSerializer
    public interface IJsonSerializer : ISerializer { }
    #endregion IJsonSerializer

    #region IXmlSerializer
    public interface IXmlSerializer : ISerializer { }
    #endregion IXmlSerializer

    #region IBinarySerializer
    public interface IBinarySerializer : ISerializer { }
    #endregion IBinarySerializer
}
