#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: DataType.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By  Robert.Luo at 2/06/2009 10:24:21 AM

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DataType.
	/// </summary>
	/// 
	
	public class DataType
	{
		public DataType()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "type")]
		public string type;

		[XmlElement(ElementName = "enumeration")]
		public StringList enumeration;

		[XmlElement(ElementName = "enumerationListId")]
		public string enumerationListId;

	    [XmlElement(ElementName = "Enumerations")]
        public Enumerations enumerations;

		[XmlElement(ElementName = "inputRange")]
		public Range inputRange;

		[XmlElement(ElementName = "readOnly")]
		public bool readOnly;

        [XmlElement(ElementName = "inputRequired")]
        public bool inputRequired;

        [XmlElement(ElementName = "fieldType")]
        public string fieldType;
	}
}
