using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetDepartmentsResponse.
	/// </summary>
	public class GetDepartmentsResponse:OperationResponse
	{
		public GetDepartmentsResponse()
		{

		}
        [XmlElement(ElementName = "Departments")]
	    public Departments Departments;
	}
}
