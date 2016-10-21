using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetStandardCommentListOut.
	/// </summary>
	public class GetStandardCommentsResponse
	{
		public GetStandardCommentsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "StandardComments")]
		public StandardComments standardComments;

        [XmlElement(ElementName = "StandardCommentsGroups")]
        public StandardCommentsGroups standardCommentsGroups;
	}
}
