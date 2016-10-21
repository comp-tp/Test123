using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalInformationGroupId.
	/// </summary>
	public class AdditionalInformationGroupId
	{
		public AdditionalInformationGroupId()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;
		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;
	}
}
