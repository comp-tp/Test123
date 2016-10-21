#region Header

/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: Status
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 * 
 *  Description:Status
 *  
 * 
 *  Note
 *  Created By:
 *  Modified By:
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    /// <summary>
    /// Summary description for Status.
    /// </summary>
    /// 
    public class Status
    {
        public Status()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "Value")]
        public string val;

        [XmlElement(ElementName = "Date")]
        public string date;

        [XmlElement(ElementName = "Time")]
        public string time;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        ///Author:Liner
        ///Date:2008-01-14
        ///Desc:06239
        [XmlElement(ElementName = "Applied")]
        public string Applied;

        ///Author:Daniel Deng
        ///Date:2009-10-13
        ///Desc:22175
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;

        /// <summary>
        /// status group
        /// </summary>
        [XmlElement(ElementName = "CapStatusGroup")]
        public Identifier StatusGroup;
    }
    ///Author:Robert luo
    ///Date:2008-01-25
    ///Desc:AAM didn't support Applied element. so I added a AAMStatus
    public class AAMStatus
    {
        public AAMStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "Value")]
        public string val;

        [XmlElement(ElementName = "Date")]
        public string date;

        [XmlElement(ElementName = "Time")]
        public string time;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;
    }
}
