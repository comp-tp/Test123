#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssets.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Tonee at 3/26/2009 7:31:00 PM
*  Notes:
* </pre>
*/

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for Parcel.
    /// </summary>
    public class Parcel
    {
        public Parcel()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;

        [XmlElement(ElementName = "contextType")]
        public string contextType;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "Text")]
        public string text;

        [XmlElement(ElementName = "SpatialDescriptors")]
        public SpatialDescriptors spatialDescriptors;

        [XmlElement(ElementName = "CompactAddresses")]
        public CompactAddresses compactAddresses;

        [XmlElement(ElementName = "Addresses")]
        public DetailAddresses detailAddresses;

        [XmlElement(ElementName = "Contacts")]
        public Contacts contacts;

        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;

        [XmlElement(ElementName = "CAPs")]
        public CAPs CAPs;

        [XmlAttribute(AttributeName = "action")]
        public string action;

        [XmlElement(ElementName = "GISObjects")]
        public GISObjects GISObjects;

        //Author:Liner Lin
        //Date:2008-10-04
        //Desc:03707 Apply Parcel Conditions
        [XmlElement(ElementName = "Conditions")]
        public Conditions Conditions;
        //end

        /// <summary>
        /// It is being added for "Feature of Parcel Summary Page Enhancement 09ACC-07502" of the version 705 of AMO
        /// </summary>
        [XmlElement(ElementName = "LegalDescription")]
        public string LegalDescription;

        /// <summary>
        /// It is being added for Feature "Parcel Summary Page Enhancement 09ACC-07502" of the version 705 of AMO
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public Status status;

        /// <summary>
        /// It is being added for Feature "Parcel Summary Page Enhancement 09ACC-07502" of the version 705 of AMO
        /// </summary>
        [XmlElement(ElementName = "ParentGenealogy")]
        public ParcelRelations ParentGenealogy;

        /// <summary>
        /// It is being added for Feature "Parcel Summary Page Enhancement 09ACC-07502" of the version 705 of AMO
        /// </summary>
        [XmlElement(ElementName = "ChildGenealogy")]
        public ParcelRelations ChildGenealogy;

    }

    public class ParcelRelations
    {
        public ParcelRelations()
        {

        }

        [XmlElement(ElementName = "ParcelRelation")]
        public ParcelRelation[] ParcelRelation;

        /// <summary>
        /// the parcel transaction time
        /// </summary>
        [XmlElement(ElementName = "TransactionTime")]
        public string TransactionTime;

    }
    public class ParcelRelation:Identifier
    {
        public ParcelRelation()
        {

        }
        /// <summary>
        /// context type is enum (Parent,Sibling,Child)
        /// </summary>
        [XmlElement(ElementName = "ContextType")]
        public string ContextType;
        /// <summary>
        /// type is enum(Split,Merge)
        /// </summary>
        [XmlElement(ElementName = "Type")]
        public string Type;
    }
}
