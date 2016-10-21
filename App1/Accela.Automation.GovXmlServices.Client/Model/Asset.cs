/**
* <pre>
* 
*  Accela Mobile Office
*  File: Asset.cs
* 
*  Accela, Inc.
*  Copyright (C): 2009-2010
* 
*  Description:
*  Create By star.li at 22/05/2009 6:11:02 PM
*  Notes:
* </pre>
*/

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Asset
	{
		public Asset()
		{
		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName="contextType")]
		public string contextType;

		[XmlElement(ElementName="Type")]
		public Type type;

		[XmlElement(ElementName="Status")]
		public Status status;

		[XmlElement(ElementName="Description")]
		public string description;

		[XmlElement(ElementName = "DescriptionIdentifier")] 
		public Enumeration descriptionIdentifier;

		[XmlElement(ElementName="Comments")]
		public string comments;

		[XmlElement(ElementName="AdditionalInformation")]
		public AdditionalInformation additionalInformation;

		[XmlElement(ElementName="startValue")]
		public double startValue;

		[XmlElement(ElementName="usefulLife")]
		public double usefulLife;

		[XmlElement(ElementName="dateOfService")]
		public string dateOfService;

		[XmlElement(ElementName="salvageValue")]
		public double salvageValue;

		[XmlElement(ElementName="currentValue")]
		public double currentValue;

		[XmlElement(ElementName="startDate")]
		public string startDate;


		[XmlElement(ElementName = "statusDates")]
		public string statusDates;

		[XmlElement(ElementName="endDate")]
		public string endDate;

		[XmlElement(ElementName="depreciationAmount")]
		public double depreciationAmount;

		[XmlElement(ElementName="depreciationValue")]
		public double depreciationValue;

		[XmlAttribute(AttributeName = "action")]
		public string action;

		//Author:Liner
		//Date:2008-02-28
		//Desc:07588 GIS
		[XmlElement(ElementName = "GISObjects")]
		public GISObjects GISObjects;
		//end

		[XmlElement(ElementName = "PartInventoryIds")]
		public PartInventoryIds PartInventoryIds;

		[XmlElement(ElementName = "Order")]
		public string Order;

		[XmlElement(ElementName = "CompletedDate")]
		public string CompletedDate;
		
		[XmlElement(ElementName = "size")]
		public string size;

		[XmlElement(ElementName = "SizeUnit")] 
		public Identifier SizeUnit;

		[XmlElement(ElementName = "costLTD")] 
		public string costLTD;

		[XmlElement(ElementName = "classType")] 
		public string classType;

		[XmlElement(ElementName = "AssetParentID")]
		public AssetId AssetParentID;

		[XmlElement(ElementName = "Usages")]
		public Usages usages;

		[XmlElement(ElementName = "assetName")]
		public string Name;

		[XmlElement(ElementName = "shortNotes")]
		public string shortNotes;
	}
}
