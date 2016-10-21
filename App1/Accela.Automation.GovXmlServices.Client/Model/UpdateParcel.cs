using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class UpdateParcel : OperationRequest
    {
        //Author:Liner Lin
        //Date:2008-09-25
        //Desc:08ACC-03707 Apply Parcel Conditions
        public UpdateParcel()
        {
        }
        [XmlElement(ElementName = "Parcel")]
        public Parcel parcel;
    }
}
