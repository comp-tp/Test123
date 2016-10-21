using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Automation.GovXmlClient.Model;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    /// <summary>
    ///  this is asset ca response class
    /// </summary>
    public class CreateAssetCAResponse : OperationResponse
    {
        #region Fields

        /// <summary>
        ///  Return asset ca id.
        /// </summary>
        [XmlElement(ElementName = "assetCAId")]
        public string AssetCAId;

        #endregion Fields
    }
}
