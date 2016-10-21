#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File:  DsAssetUnitTypes.cs
*
*  Accela, Inc.
*  Copyright (C): 2010
*
*  Description:
*  Create By Derek Zhan at 5/7/2009 5:31:09 PM
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
    public class GetStandardChoicesResponse : OperationResponse
    {
        public GetStandardChoicesResponse()
       {
           
       } 

        [XmlElement(ElementName = "standardChoiceType")]
        public string standardChoiceType;

        [XmlElement(ElementName = "StandardChoices")] 
        public Enumerations standardChoices;

    }
}
