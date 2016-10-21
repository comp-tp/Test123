using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace Accela.Core.Serialization.JsonNet
{
    public class BsonNetSerializer : SerializerBase, IBinarySerializer
    {
        public override bool IsBinary
        {
            get { return true; }
        }

        public override void Serialize(Stream stream, object obj, Type objType = null, SerializerSettings settings = null)
        {
            using (var jsonWriter = new BsonWriter(stream))
            {
                jsonWriter.CloseOutput = false;

                if (settings != null)
                    jsonWriter.Formatting = (Newtonsoft.Json.Formatting)settings.Formatting;

                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, obj, objType);
            }
        }

        public override object Deserialize(Stream stream, Type objType, SerializerSettings settings = null)
        {
            using (var jsonReader = new BsonReader(stream))
            {
                jsonReader.CloseInput = false;

                var serializer = new JsonSerializer();
                return serializer.Deserialize(jsonReader, objType);
            }
        }

    }
}
