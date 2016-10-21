/**
 * <pre>
 * 
 *  Accela Mobile Server
 *  File: MapService.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 *  Map service client model
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
    public class MapService
    {
        public MapService()
        {
        }

        [XmlAttribute(AttributeName = "action")]
        public string action;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "order")]
        public string order;

        [XmlElement(ElementName = "name")]
        public string name;

        [XmlElement(ElementName = "gisServiceId")]
        public string gisServiceId;

        [XmlElement(ElementName = "url")]
        public string url;
    }
}
