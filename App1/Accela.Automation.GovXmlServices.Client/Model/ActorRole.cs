#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: ActorRole.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 8/17/2009 4:11:04 PM
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ActorRole.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
	public class ActorRole
	{
		public ActorRole()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "role")]
		public string role;

		[XmlElement(ElementName = "userDefinedRole")]
		public string userDefinedRole;

        [XmlElement(ElementName = "UserDefinedRoleId")]
        public Enumeration userDefinedRoleId;
	}
}
