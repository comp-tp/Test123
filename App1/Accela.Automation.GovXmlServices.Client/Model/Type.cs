using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Type.
	/// </summary>
	/// 
	public class Type
	{
		public Type()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

        [XmlElement(ElementName = "StandardCommentsGroups")]
        public StandardCommentsGroupIds standardCommentsGroups;
	}
}
