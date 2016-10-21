/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetAssetUsagesResponse.cs
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
	public class GetAssetUsagesResponse
	{
		public GetAssetUsagesResponse()
		{
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "Usages")]
        public Usages usages;
	}
}