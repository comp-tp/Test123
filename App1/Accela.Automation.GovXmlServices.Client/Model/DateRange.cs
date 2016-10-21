#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: DateRange.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Tonee at 3/26/2009 7:31:00 PM
*  Notes:
* </pre>
*/

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DateRange.
	/// </summary>
	public class DateRange
	{
		public DateRange()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "from")]
		public string from;

		[XmlElement(ElementName = "fromConstraint")]
		public string fromConstraint;

		[XmlElement(ElementName = "to")]
		public string to;

		[XmlElement(ElementName = "toConstraint")]
		public string toConstraint;

		[XmlElement(ElementName = "processValue")]
		public string processValue;
	}
}
