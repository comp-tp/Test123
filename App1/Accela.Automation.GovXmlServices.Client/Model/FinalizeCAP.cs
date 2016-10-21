using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model

{
	/// <summary>
	/// Summary description for FFinalizeCAPIn.
	/// </summary>
	public class FinalizeCAP
	{
		public FinalizeCAP()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;
	}
}
