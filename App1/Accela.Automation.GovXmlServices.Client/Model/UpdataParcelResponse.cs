using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    //Author:Liner Lin
    //Date:2008-10-04
    //Desc:03707 Apply Parcel Conditions
    /// <summary>
    /// 
    /// </summary>
    public class UpdataParcelResponse : OperationResponse
    {
        public UpdataParcelResponse()
        {
        }

        [XmlElement(ElementName = "Parcel")]
        public Parcel parcel;

    }
}
