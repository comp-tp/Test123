/**
 * <pre>
 * 
 *  Accela Mobile Server
 *  File: GetGISSettings.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 *  Get GIS settins
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
    public class GetGISSettings
    {
        public GetGISSettings()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "DetailAddress")]
		public List<MapService> mapServices;
    }
}
