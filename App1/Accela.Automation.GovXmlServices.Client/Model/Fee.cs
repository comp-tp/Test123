using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Fee
	{
		public Fee()
		{
		}
		[XmlElement(ElementName="totalAssessedAmount")]
		public double totalAssessedAmount;

		[XmlElement(ElementName="totalPaidAmount")]
		public double totalPaidAmount;

		[XmlElement(ElementName="transactionDueAmount")]
		public double transactionDueAmount;

		[XmlElement(ElementName="transactionPaymentAmount")]
		public double transactionPaymentAmount;

		[XmlElement(ElementName="Comments")]
		public string Comments;

		[XmlElement(ElementName="quantity")]
		public double quantity;
	}
}
