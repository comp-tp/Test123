using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for HoldTypes.
	/// </summary>
	public class HoldTypes
	{
		public HoldTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="HoldType")]
		public HoldType[] holdType;
	}
}
