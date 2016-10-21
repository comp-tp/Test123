﻿﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetTimeAccountingTypesResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2010
*
*  Description:
*  Create By Derek Zhan 2010
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
   public class GetTimeAccountingTypesResponse : OperationRequest
    {
       public GetTimeAccountingTypesResponse()
       {
           
       }

       [XmlElement(ElementName = "TimeAccountingTypes")]
       public TimeAccountingTypes TimeAccountingTypes;
      
    }

}