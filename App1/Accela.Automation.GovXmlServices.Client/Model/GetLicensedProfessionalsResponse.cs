using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    //Author:Liner Lin
    //Date:2008-09-23
    //Desc:06ACC-00918 Search Licensed Professional
    /// <summary>
    /// Get Licensed Professionals Response
    /// </summary>
    public class GetLicensedProfessionalsResponse:OperationResponse
    {
        public GetLicensedProfessionalsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Contacts")]
        public Contacts contacts;
    }
}
