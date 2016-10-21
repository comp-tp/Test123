/*
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: CommentLogic.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 *  Create By Ness Su at 10/11/2011
 *  
 *  
 *  
 *  Notes:
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CAPComment
    {
        public CAPComment()
        {
        }
        [XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string globalId;

        [XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string ownerHistory;

        [XmlElement(ElementName = "userID")]
        public string UserID;

        [XmlElement(ElementName = "Keys")]
        public Keys Keys;

        [XmlElement(ElementName = "identifierDisplay")]
        public string IdentifierDisplay;

        [XmlElement(ElementName = "comments")]
        public string Comments;

        [XmlElement(ElementName = "date")]
        public string Date;

        [XmlElement(ElementName = "showOnInspection")]
        public string ShowOnInspection;

        [XmlAttribute(AttributeName = "action")]
        public string action;

    }
}
