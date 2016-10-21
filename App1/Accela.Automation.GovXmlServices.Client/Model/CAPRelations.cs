using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAP.
	/// </summary>
	/// 
	
	public class CAPRelations
	{
		[XmlElement(ElementName = "CAPRelation")]
		public CAPRelation[] capRelation;
	}
}