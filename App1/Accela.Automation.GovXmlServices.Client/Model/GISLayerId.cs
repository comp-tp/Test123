#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File:
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *  Create by: star.li
 *  Notes:
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;


namespace Accela.Automation.GovXmlClient.Model
{
    public class GISLayerId
    {
        [XmlElement(ElementName = "Keys")]
        public Keys Keys;
    }
}
