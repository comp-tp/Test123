/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: Types.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Note
 *  Created By: Pearl Luo
 *
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Types
	{
        public Types()
		{
		}
        [XmlElement(ElementName = "Type")]
        public Type[] type;
	}
}