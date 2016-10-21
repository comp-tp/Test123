using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Addresses.
	/// </summary>
	/// 
	public class Addresses
	{
		public Addresses()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "PostalAddress")]
		public PostalAddress postalAddress;

		[XmlElement(ElementName = "TelecomAddress")]
		public TelecomAddress telecomAddress;

        //  Author:Winsean Wang
        //  Date:10/07/2008
        //  Desc:06ACC-01900
        DetailAddress[] _detailAddresses = null;
        [XmlElement(ElementName = "DetailAddress")]
        public DetailAddress[] detailAddress
        {
            get
            {
                return _detailAddresses;
            }
            set
            {
                _detailAddresses = value;
            }
        }
        //  end

		[XmlElement(ElementName = "CompactAddress")]
		public CompactAddress[] CompactAddresses;
	}
}
