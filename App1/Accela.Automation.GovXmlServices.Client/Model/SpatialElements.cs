using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SpatialElements.
	/// </summary>
	public class SpatialElements
	{
		public SpatialElements()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="SpatialElement")]
		public SpatialElement[] SpatialElement;
	}
}
