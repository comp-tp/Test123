using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPs.
	/// </summary>
	/// 
	
	public class CAPs
	{
		public CAPs()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "CAP", IsNullable = true)]
		public CAP[] cap;
	}
}
