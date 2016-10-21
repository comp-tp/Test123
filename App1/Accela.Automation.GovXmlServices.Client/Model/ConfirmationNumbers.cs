#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: ConfirmationNumbers.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2010
 *
 *  Description:
 *  This is ConfirmationNumbers's model
 *
 *  Note
 *  Created By: Code Generator
 *
 * </pre>
 */
#endregion
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class ConfirmationNumbers
	{
		public ConfirmationNumbers()
		{
		}
        [XmlElement(ElementName = "ConfirmationNumber", IsNullable = true)]
        public string[] ConfirmationNumber;
	}
}

