using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ParcelIds.
	/// </summary>
	public class ParcelIds
	{
		public ParcelIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "ParcelId")]
		public ParcelId[] parcelId;
	}
}
