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
    public class CAPComments
    {
        public CAPComments()
        {
        }
        [XmlElement(ElementName = "Comment")]
        public CAPComment[] comment;
    }
}
