using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.BusinessEntities.ImageHelpers
{
    public class StreamHelper
    {

        public static string GetFileBase64String(Stream stream)
        {
            string result = String.Empty;

            if (stream != null)
            {
                stream.Position = 0;
                int streamLength = (int)stream.Length;
                var bytes = new byte[streamLength];
                stream.Read(bytes, 0, streamLength);
                result = Convert.ToBase64String(bytes);
            }

            return result;
        }

    }
}
