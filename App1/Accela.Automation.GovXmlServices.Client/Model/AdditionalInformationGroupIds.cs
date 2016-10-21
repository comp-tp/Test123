using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalInformationGroupIds.
	/// </summary>
	public class AdditionalInformationGroupIds
	{
		public AdditionalInformationGroupIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "AdditionalInformationGroupId")]
		public AdditionalInformationGroupId[] additionalInformationGroupId;
	}
}
