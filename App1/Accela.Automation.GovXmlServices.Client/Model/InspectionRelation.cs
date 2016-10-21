/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: InspectionRelations.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2010
 *
 *  Description:
 *  The class is used to write object to binary file or binary stream.
 *
 *  Note
 *  Created By: Pearl Luo
 *  Create Date:
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for InspectionRelation.
    /// </summary>
    public class InspectionRelation
    {
        [XmlElement(ElementName = "contextType")]
        public string contextType;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;
    }
}