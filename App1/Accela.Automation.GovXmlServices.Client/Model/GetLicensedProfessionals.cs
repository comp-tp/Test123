using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    //Author:Liner Lin 
    //Date:2008-09-22
    //Desc:06ACC-00918 Search Licensed Professional
    /// <summary>
    /// Summary description for GetLicensedProfessionals.
	/// </summary>
    public class GetLicensedProfessionals:OperationRequest
	{
        public GetLicensedProfessionals()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        [XmlElement(ElementName = "Person")]
        public Person person;

        [XmlElement(ElementName = "Organization")]
        public Organization organization;

        [XmlElement(ElementName = "PersonAndOrganization")]
        public PersonAndOrganization personAndOrganization;

        [XmlElement(ElementName = "License")]
        public License license;
	}
}
