﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: TimeAccountingGroups.cs
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
    public class TimeAccountingGroups
    {
        public TimeAccountingGroups()
        {
        }

        [XmlElement(ElementName = "TimeAccountingGroup")]
        public TimeAccountingGroup[] TimeAccountingGroup;
    }

    public class TimeAccountingGroup : Identifier
    {
        public TimeAccountingGroup()
        {
        }

        [XmlElement(ElementName = "TimeAccountingTypes")]
        public TimeAccountingTypes TimeAccountingTypes;

        [XmlElement(ElementName = "Security")]
        public string security;

    }
}
