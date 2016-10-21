using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ObjectId.
	/// </summary>
	public class ObjectId:Identifier
	{
		public ObjectId()
		{
		}

		[XmlElement(ElementName="contextType")]
		public string contextType;
	}
}
