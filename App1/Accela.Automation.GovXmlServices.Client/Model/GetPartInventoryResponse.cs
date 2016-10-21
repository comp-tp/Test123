using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetPartInventoryResponse.
	/// </summary>
    public class GetPartInventoryResponse : OperationResponse
    {
        [XmlElement(ElementName = "PartInventories")]
        public PartInventories PartInventories;
    }
}
