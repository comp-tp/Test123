#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssetCAStatusResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/4/2009 3:12:55 PM
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    public class GetAssetCAStatusResponse : OperationResponse
    {
        /// <summary>
        ///  this only contain asset ca status 
        /// </summary>
        [XmlElement(ElementName = "Dispositions")]
        public Dispositions dispositions;
    }
}
