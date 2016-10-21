/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: Roles.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *  Create by:Pearl.luo
 *  Notes:
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Roles.
	/// </summary>
	/// 
	public class Roles
	{
		public Roles()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Role")]
		public string[] role;

        [XmlElement(ElementName = "RoleEnumerations")]
        public Enumerations AMORoleType;
	}
}
