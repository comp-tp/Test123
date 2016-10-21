#region Header

/**
/**
* <pre>
*
*  Accela Mobile Office
*  File: AddressesResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description:
*  Create By Daniel Shi at 1/24/2011 11:03:18 AM

*  Revision History:
*  Date                  Who                What
*
* </pre>
*/

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Addresses Response
    /// </summary>
    public class AddressesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressesResponse"/> class.
        /// </summary>
        public AddressesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "Addresses")]
		public Addresses addresses;
    }
}
