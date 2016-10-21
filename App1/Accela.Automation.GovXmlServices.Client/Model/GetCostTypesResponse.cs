using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetCostTypesResponse.
	/// </summary>
    public class GetCostTypesResponse:OperationResponse
    {
        [XmlElement(ElementName = "CostTypes")]
        public CostTypes CostTypes;

        [XmlElement(ElementName = "CostFactors")]
        public CostFactors CostFactors;
    }
}
