/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: Cities.cs
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
	/// Summary description for Cities.
	/// </summary>
	public class Cities
	{
		public Cities()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName="City")]
		public string[] city;

        [XmlElement(ElementName = "CityEnumerations")]
        public Enumerations AMOCity;
	}
}
