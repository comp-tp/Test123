using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// This serves as the parent class for both AddressLines and AddressLinesIFC
	/// </summary>
	/// 
	public abstract class AddressLinesBase
	{
		public AddressLinesBase()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "String")]
		public string[] str;


	}
}
