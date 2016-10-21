#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File:
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *
 *
 *  Note
 *  Created By: Code generator
 *
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Roles.
	/// </summary>
	/// 
	public class LicenseTypes
	{
		public LicenseTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "LicenseType")]
		public string[] licenseType;


        [XmlElement(ElementName = "LicenseTypeEnumerations")]
        public Enumerations AMOLicenseType;
	}
}
