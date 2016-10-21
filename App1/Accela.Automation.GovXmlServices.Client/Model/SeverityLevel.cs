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
 *  Created By: Winsean Wang
 *
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SeverityLevel.
	/// </summary>
	public class SeverityLevel
	{
		public SeverityLevel()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

        [XmlElement(ElementName = "Level")]
		public string level;
	}
}
