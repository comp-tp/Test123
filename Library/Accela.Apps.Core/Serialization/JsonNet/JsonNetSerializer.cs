using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Accela.Core.Serialization.JsonNet
{
    public class JsonNetSerializer : SerializerBase, IJsonSerializer
    {
        public override void Serialize(Stream stream, object obj, Type objType = null, SerializerSettings settings = null)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 512, true))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var serializer = new JsonSerializer();
                jsonWriter.CloseOutput = false;
                
                if (settings != null)
                {
                    jsonWriter.Formatting = (Newtonsoft.Json.Formatting)settings.Formatting;
                    serializer.MaxDepth = settings.MaxDepth;
                    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                }                
                
                //serializer.Converters.Add(new SqlGeographyConverter());
                serializer.Serialize(jsonWriter, obj, objType);
            }
        }

        public override object Deserialize(Stream stream, Type objType, SerializerSettings settings = null)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8, false, 512, true))
            using (var jsonReader = new JsonTextReader(reader))
            {
                jsonReader.CloseInput = false;

                var serializer = new JsonSerializer();
                //serializer.Converters.Add(new SqlGeographyConverter());
                return serializer.Deserialize(jsonReader, objType);
            }
        }


        public override bool IsBinary
        {
            get { return false; }
        }
    }
}
