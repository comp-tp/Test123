using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalInformation.
	/// </summary>
	/// 
	
	public class AdditionalInformation
	{
		public AdditionalInformation()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "AdditionalInformationGroup")]
		public AdditionalInformationGroup[] additionalInformationGroup;
	}
}
