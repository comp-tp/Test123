using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Conditions.
	/// </summary>
	/// 
	
	public class Conditions
	{
		public Conditions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Condition", IsNullable = true)]
		public Condition[] condition;
	}
}
