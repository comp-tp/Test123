
﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssetSizeUnitsResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description:
*  Create By Derek Zhan at 9/3/2009 5:50:03 PM
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
  public  class GetAPOTemplateResponse : OperationResponse
    {
      public GetAPOTemplateResponse()
      {
          
      }
      [XmlElement(ElementName = "APOTemplates")]
      public APOTemplates APOTemplates;
    }
}
