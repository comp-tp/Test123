using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for roles_ifc.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "roles")]
	public class roles_ifc
	{
		public roles_ifc()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "ActorRole")]
		public ActorRole actorRole;
	}
}
