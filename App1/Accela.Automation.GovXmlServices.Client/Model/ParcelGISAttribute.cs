/**
 * <pre>
 * 
 *  Accela Mobile Server
 *  File: ParcelGISAttribute.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 *  Parcel GIS attribute client model
 * 
 *  Note
 *  Created By: carver li
 * </pre>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    public class ParcelGISAttribute
    {
        public ParcelGISAttribute()
        {
        }

        [XmlAttribute(AttributeName = "action")]
        public string action;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "GISServiceId")]
        public string gisServiceID;

        [XmlElement(ElementName = "LayerName")]
        public string layerName;

        [XmlElement(ElementName = "IDField")]
        public string idField;
    }
}
