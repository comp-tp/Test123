/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetAssetUsages.cs
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
	/// <summary>
	/// Summary description for GetAssetUsages.
	/// </summary>
	public class GetAssetUsages
	{
        public GetAssetUsages()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "AssetIds")]
        public AssetIds assetIds;

        [XmlElement(ElementName = "previousUsagesNumber")]
        public string previousUsagesNumber;
	}
}