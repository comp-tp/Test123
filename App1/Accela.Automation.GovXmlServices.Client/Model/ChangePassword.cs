/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: ChangePassword.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008
 * 
 *  Description:
 *  All DataModel class must inherit the class.
 * 
 *  Note
 *  Created By: Tonee
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class ChangePassword : OperationRequest
    {
        [XmlElement(ElementName = "Keys")]
        public string Keys;

        [XmlElement(ElementName = "OldPassword")]
        public string OldPassword;

        [XmlElement(ElementName = "NewPassword")]
        public string NewPassword;
    }

    public class ChangePasswordResponse : OperationResponse
    {
    }
}
