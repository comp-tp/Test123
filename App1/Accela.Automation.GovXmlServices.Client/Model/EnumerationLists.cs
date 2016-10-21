using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for EnumerationLists.
	/// </summary>
	public class EnumerationLists
	{
		public EnumerationLists()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "EnumerationList")]
		public EnumerationList[] enumerationList;
	}
}
