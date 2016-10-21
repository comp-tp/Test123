/**
* <pre>
*
*  Accela Mobile Office
*  File: ElementList.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Robert at 10/28/2009
*  Notes:
* </pre>
*/

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class ElementList
	{
		public ElementList()
		{
		}
		[XmlAttribute(AttributeName="elementCount")]
		public string elementCount;
	}
}
