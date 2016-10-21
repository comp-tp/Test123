/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: AssetSecurity.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 *  This is AssetSecurity model
 * 
 *  Note
 *  Created By: derek zhan
 *
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Asset.
	/// </summary>
	/// 

    public class AssetSecurity
    {
        public AssetSecurity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// entity
        /// </summary>
        [XmlElement(ElementName = "Entity")]
        public Entity[] Entity;

    }
}
