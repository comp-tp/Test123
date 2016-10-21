using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Accela.Core.Serialization.DataContract
{
    public class XmlDataContractSerializer : SerializerBase, IXmlSerializer
    {
        public override void Serialize(Stream stream, object obj, Type objType = null, SerializerSettings settings = null)
        {
            if (objType != null &&
                obj != null)
            {
                var serializerSettings = (settings == null) ? null : new DataContractSerializerSettings(settings);
                var serializer = this.CreateSerializer(objType, (serializerSettings == null) ? null : serializerSettings.KnownTypes);

                using (var xmlWriter = XmlTextWriter.Create(stream, 
                    new XmlWriterSettings 
                    { 
                        Encoding = Encoding.UTF8, 
                        CloseOutput = false,
                        Indent = (serializerSettings != null && serializerSettings.Formatting == Formatting.Indented)
                    }))
                {
                    serializer.WriteObject(xmlWriter, obj);
                    xmlWriter.Flush();
                }
            }
        }

        public override object Deserialize(Stream stream, Type objType, SerializerSettings settings = null)
        {
            object deserialized = null;

            if (objType != null)
            {
                var serializerOptions = (settings == null) ? null : new DataContractSerializerSettings(settings);
                var serializer = this.CreateSerializer(objType, (serializerOptions == null) ? null : serializerOptions.KnownTypes);

                using (var xmlReader = XmlTextReader.Create(stream, new XmlReaderSettings{ CloseInput = false }))
                {
                    deserialized = serializer.ReadObject(xmlReader);
                }
            }

            return deserialized;
        }

        public override bool IsBinary
        {
            get { return false; }
        }

        private DataContractSerializer CreateSerializer(Type type, Type[] knownTypes)
        {
            return (knownTypes == null)
                ? new DataContractSerializer(type)
                : new DataContractSerializer(type, knownTypes);
        }
    }

    #region DataContractSerializerSettings
    public class DataContractSerializerSettings : SerializerSettings
    {
        public DataContractSerializerSettings()
        {
        }

        public DataContractSerializerSettings(SerializerSettings settings)
        {
            //transfer over generic properties
            //transfer over type specific properties
            var serializerOptions = settings as DataContractSerializerSettings;

            if (serializerOptions != null)
                this.KnownTypes = serializerOptions.KnownTypes;
        }

        public Type[] KnownTypes { get; set; }
    }
    #endregion DataContractSerializerSettings
}
