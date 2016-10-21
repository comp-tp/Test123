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
 *  Create by: star.li
 *  Notes:
 * </pre>
 */

#endregion Header


using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GISObject.
	/// </summary>
	public class GISObject
	{
		public GISObject()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys Keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string IdentifierDisplay;

		[XmlElement(ElementName="DetailAddresses")]
		public DetailAddresses detailAddresses;

        [XmlAttribute(AttributeName = "action")]
        public string action;

        [XmlElement(ElementName = "MapServiceId")]
        public MapServerID MapServerID;

        [XmlElement(ElementName = "GISLayerId")]
        public GISLayerId GISLayerId;
	}
}
