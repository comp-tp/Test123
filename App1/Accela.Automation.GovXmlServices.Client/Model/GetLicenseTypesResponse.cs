using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetRoleListOut.
	/// </summary>
	public class GetLicenseTypesResponse
	{
		public GetLicenseTypesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "LicenseTypes")]
		public LicenseTypes licenseTypes;

	}
}
