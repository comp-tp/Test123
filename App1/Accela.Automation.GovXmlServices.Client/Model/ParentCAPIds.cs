using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPIds.
	/// </summary>
	public class ParentCAPIds
	{
		public ParentCAPIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "CAPId")]
		public CAPId[] capId;
	}
}
