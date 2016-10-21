#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetUnitTypeHelper.cs
*
*  Accela, Inc.
*  Copyright (C): 2010
*
*  Description:
*  Create By STAR-LI at 2010 5:31:09 PM
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/
#endregion Header
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
  public  class UnitType
    {
      public UnitType()
      {
          
      }
      [XmlElement(ElementName = "AssetUnitTypes")]
      public AssetUnits AssetUnits;
    }

  /// <summary>
  /// This is a AssetUnits 
  /// </summary>
  public class AssetUnits
  {
      public AssetUnits()
      {
          //
          // TODO: Add constructor logic here
          //
      }

      [XmlElement(ElementName = "AssetUnitType", IsNullable = true)]
      public AssetUnit[] AssetUnit;
  }

  public class AssetUnit
  {
      public AssetUnit()
      {
          //
          // TODO: Add constructor logic here
          //
      }

      [XmlElement(ElementName = "AssetUnitIdentify")] 
      public Identifier AssetUnitIdentify;

  }
}
