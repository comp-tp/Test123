#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File:  DsAssetUnitTypes.cs
*
*  Accela, Inc.
*  Copyright (C): 2010-2011
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
    public class GetStandardChoices : OperationRequest
    {
       public GetStandardChoices()
       {
           
       }

        [XmlElement(ElementName = "standardChoiceType")]
        public string standardChoiceType;

        /// <summary>
        /// It added by robert at 2011-6-29
        /// </summary>
        [XmlElement(ElementName = "standardChoiceValue")]
        public string standardChoiceItem;
    }
}
