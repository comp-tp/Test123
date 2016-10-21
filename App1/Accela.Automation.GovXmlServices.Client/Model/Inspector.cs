/**
* <pre>
* 
*  Accela Mobile Office
*  File: Inspector.cs
* 
*  Accela, Inc.
*  Copyright (C): 2009-2010
* 
*  Description:
*  Create By Robert Luo at 5/8/2009
*  Notes:
* </pre>
*/
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Inspector.
	/// </summary>
	/// 
	public class Inspector
	{
		public Inspector()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "Person", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public Person person;

		[XmlElement(ElementName = "Organization", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public Organization organization;

		[XmlElement(ElementName = "PersonAndOrganization", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public PersonAndOrganization personAndOrganization;

        [XmlElement(ElementName = "Active")]
        public bool Active;
	}
}
