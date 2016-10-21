using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Organization.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
	public class Organization
	{
		public Organization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "id")]
		public string id;

		[XmlElement(ElementName = "name")]
		public string name;

		[XmlElement(ElementName = "description")]
		public string description;

		[XmlElement(ElementName = "roles")]
		public roles_ifc roles;

		[XmlElement(ElementName = "addresses")]
		public Addresses addresses;

        //Author:Archer Wang
        //Date:2011-10-27
        //Desc:Add a new field named contactBusinessName
        [XmlElement(ElementName = "contactBusinessName")]
        public string contactBusinessName;
	}
}
