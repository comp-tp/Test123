using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PostMileageResponse.
	/// </summary>
	public class PostMileageResponse
	{
		[XmlElement(ElementName = "System")]
		public Sys system;

		public PostMileageResponse()
		{
		}
	}
}
