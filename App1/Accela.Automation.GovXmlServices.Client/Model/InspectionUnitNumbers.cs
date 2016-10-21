/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: InspectionUnitNumbers.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 * 
 *  Description:
 *  This is InspectionListLogic's Logic
 * 
 *  Note
 *  Created By: Winsen Wang
 *  
 * Modified by Winsean Wang
 * refactored
 *  
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionUnitNumbers.
	/// </summary>
	/// 
	public class InspectionUnitNumbers
	{
		public InspectionUnitNumbers()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "InspectionUnitNumber")]
		public string[] inspectionUnitNumber;

        /// <summary>
        /// The inspection unit numbers supporting the localization and globalization.
        /// </summary>
        [XmlElement(ElementName = "InspectionUnitNumberEnumerations")]
        public InspectionUnitNumberEnumerations Enumerations;
	}
}
