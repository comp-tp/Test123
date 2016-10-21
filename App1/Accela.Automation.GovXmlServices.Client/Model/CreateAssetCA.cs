using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    using System.Xml.Serialization;
    using Accela.Automation.GovXmlClient.Model;

    /// <summary>
    ///  Create asset ca request class
    /// </summary>
    public class CreateAssetCA : OperationRequest
    {
        #region Fields

        /// <summary>
        ///  this is asset ca use to update
        /// </summary>
        [XmlElement(ElementName = "AssetCA")]
        public AssetCA assetCA;

        #endregion Fields
    }
}
