using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GISObjects.
	/// </summary>
	public class GISObjects
	{
		public GISObjects()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="GISObject")]
		public GISObject[] GISObject;
	}
}
