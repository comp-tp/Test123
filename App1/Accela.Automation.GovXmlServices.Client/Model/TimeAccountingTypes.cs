﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: TimeAccountingTypes.cs
*
*  Accela, Inc.
*  Copyright (C): 2010-2011
*
*  Description:
*  Create By Derek Zhan at 2010
*  Notes:

*  Revision History:
*  Date                  Who                What
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
    public class TimeAccountingTypes
    {
        public TimeAccountingTypes()
        {
        }

        [XmlElement(ElementName = "TimeAccountingType")]
        public TimeAccountingType[] TimeAccountingType;
    }

    public class TimeAccountingType : Identifier
    {
        public TimeAccountingType()
        {
        }

        [XmlElement(ElementName = "Usage")]
        public string usage;

        [XmlElement(ElementName = "Security")]
        public string security;

        [XmlElement(ElementName = "RecordGroup")]
        public string RecordGroupKeys;

        [XmlElement(ElementName = "RecordType")]
        public string RecordTypeKeys;

        [XmlElement(ElementName = "RecordSubType")]
        public string RecordSubTypeKeys;

        [XmlElement(ElementName = "RecordCategory")]
        public string RecordCategoryKeys;
    }
}
