#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetType.cs
*
*  Accela, Inc.
*  Copyright (C): 2010-2011
*
*  Description:
*  Create By generator
*  Notes:
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    public class AssetType : element
    {
        #region Fields

        /// <summary>
        /// the related captypes of the asset - 2009-09-07
        /// </summary>
        [XmlElement(ElementName = "CAPTypeIds")]
        public CAPTypeIds CAPTypeIds;
        [XmlElement(ElementName = "AdditionalInformationGroupIds")]
        public AdditionalInformationGroupIds additionalInformationGroupIds;
        [XmlElement(ElementName = "Description")]
        public string description;
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        /// <summary>
        /// group display value
        /// </summary>
        [XmlElement(ElementName = "Group")]
        public string Group;

        /// <summary>
        /// type display value
        /// </summary>
        [XmlElement(ElementName = "Type")]
        public string Type;

        ////Add GISService, GISLayer, GISIdForAssetId, GISAttributeMappings to asset type
        ////for feature AMOsupportsAGISCreateFeatures

        /// <summary>
        /// GIS Service
        /// </summary>
        [XmlElement(ElementName = "GISService")]
        public string GISService;

        /// <summary>
        /// edit layer of asset type
        /// </summary>
        [XmlElement(ElementName = "GISLayerId")]
        public Identifier GISLayerId;

        /// <summary>
        /// gis id for asset id
        /// </summary>
        [XmlElement(ElementName = "GISIDForAssetID")]
        public string GISIdForAssetId;

        /// <summary>
        /// GIS attribute mappings
        /// </summary>
        [XmlElement(ElementName = "GISAttributeMappings")]
        public GISAttributeMappings GISAttributeMappings;

        /// <summary>
        /// asset class data
        /// </summary>
        [XmlElement(ElementName = "classType")]
        public string Class;

        /// <summary>
        /// sizeRequired
        /// </summary>
        [XmlElement(ElementName = "sizeRequired")]
        public string SizeRequired;

        /// <summary>
        /// AssetSecurity
        /// </summary>
        [XmlElement(ElementName = "Securities")]
        public AssetSecurity Securities;

        /////// <summary>
        /////// UsageTypes
        /////// </summary>
        [XmlElement(ElementName = "UsageTypes")]
        public Types usageTypes;

        /// <summary>
        ///  Asset Access Security
        /// </summary>
        [XmlElement(ElementName = "AssetSecurity")]
        public string AssetAccessSecurity;
        #endregion Fields

        #region Constructors

        public AssetType()
        {
        }

        #endregion Constructors
    }  
   
    /// <summary>
    /// This is a GIS attribute mappings access object
    /// </summary>
    public class GISAttributeMappings
    {
        public GISAttributeMappings()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "GISAttributeMapping", IsNullable = true)]
        public GISAttributeMapping[] GISAttributeMapping;
    }

    /// <summary>
    /// This is a GIS attribute mapping access object
    /// </summary>
    public class GISAttributeMapping
    {
        public GISAttributeMapping()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// GIS attribute
        /// </summary>
        [XmlElement(ElementName = "GISAttribute")]
        public string GISAttribute;

        /// <summary>
        /// AA attribute
        /// </summary>
        [XmlElement(ElementName = "AAAtribute")]
        public string AAAtribute;
    }
}