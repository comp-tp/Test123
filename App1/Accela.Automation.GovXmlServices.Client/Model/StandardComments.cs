using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for StandardComments.
	/// </summary>
	public class StandardComments
	{
		public StandardComments()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="StandardComment")]
		public StandardComment[] standardComment;
	}
}
