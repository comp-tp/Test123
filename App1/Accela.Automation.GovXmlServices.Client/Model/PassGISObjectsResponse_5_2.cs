using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PassGISObjectsResponse_5_2.
	/// </summary>
	public class PassGISObjectsResponse_5_2
	{
		public PassGISObjectsResponse_5_2()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "ElectronicFile")]
		public ElectronicFile_5_2 electronicFile;

		[XmlElement(ElementName = "UniversalResourceLocator")]
		public string universalResourceLocator;
	}
}
