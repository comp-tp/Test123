using Accela.Apps.Shared.Exceptions;
using Accela.Core.Logging;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Accela.Apps.Shared
{
    public class XmlConverter
    {
        public static string ToXml(object xmlobj)
        {
            string returnXml = String.Empty;
            XmlSerializer serializer = new XmlSerializer(xmlobj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings { Indent = false }))
                {
                    serializer.Serialize(xmlWriter, xmlobj);
                }
                ms.Position = 0;
                using (StreamReader reader = new StreamReader(ms))
                {
                    returnXml = reader.ReadToEnd();
                }
            }

            return returnXml;
        }

        /// <summary>
        /// xml Deserialize
        /// </summary>
        public static T FromXmlTo<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                T xmlObject = (T)serializer.Deserialize(ms);
                ms.Close();
                return xmlObject;
            }
            catch (Exception ex)
            {
                LogFactory.GetLog().Error("Xml converter error", "xmlin=" + xml + "\r\nException : " + ex.TraceInformation(), "Shared.XmlConverter()");
                throw;
            }
        }
    }
}
