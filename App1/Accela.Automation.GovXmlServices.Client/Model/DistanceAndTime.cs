#region Header
/*
* <pre>
*
*  Accela Mobile Office
*  File: DistanceAndTime.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Robert Luo 
*  Notes:
*  
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
	/// Summary description for DistanceAndTime.
	/// </summary>
	public class DistanceAndTime
	{
		public DistanceAndTime()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;


        [XmlElement(ElementName = "Date")]
        public string date;

        /// <summary>
        /// Get the last updated date of inspection.
        /// </summary>
        [XmlElement(ElementName = "LastUpdateDate")]
        public string lastUpdateDate;


		[XmlElement(ElementName="time")]
		public time time;

		[XmlElement(ElementName="distance")]
		public distance distance;

		[XmlElement(ElementName="vehicleId")]
		public string vehicleId;
	}
}
