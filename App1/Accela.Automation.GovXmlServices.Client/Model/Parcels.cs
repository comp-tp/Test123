#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssets.cs
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
	/// Summary description for Parcels.
	/// </summary>
	public class Parcels
	{
		public Parcels()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Parcel")]
		public Parcel[] parcel;
	}
}
