using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// This is the parent element for a collection of Inspections
	/// </summary>
	/// 
	
	public class Inspections
	{
		public Inspections()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		[XmlElement(ElementName = "Inspection", IsNullable=true)]
		public Inspection[] inspection;
	}
}
