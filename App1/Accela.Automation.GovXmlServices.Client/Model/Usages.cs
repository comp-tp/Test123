/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: Usages.cs
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
	public class Usages
	{
		public Usages()
		{
		}
        [XmlElement(ElementName = "Usage")]
        public Usage[] usage;
	}
}