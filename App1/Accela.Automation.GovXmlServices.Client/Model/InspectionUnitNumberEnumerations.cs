/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: InspectionUnitNumberEnumerations.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Defines the inspection unit numbers which supports the globalization and localization.
    /// </summary>
    public class InspectionUnitNumberEnumerations
    {
        /// <summary>
        /// Stores the all inspection unit numbers
        /// </summary>
        [XmlElement(ElementName = "Enumeration")]
        public InspectionUnitNumberEnumeration[] Enumerations;
    }

    /// <summary>
    /// Defines a item of the inspection unit number.
    /// </summary>
    public class InspectionUnitNumberEnumeration
    {
        /// <summary>
        /// records the key value
        /// </summary>
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        /// <summary>
        /// Records the display.
        /// </summary>
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;
    }
}
