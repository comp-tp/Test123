﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: TimeAccounting.cs
*
*  Accela, Inc.
*  Copyright (C): 2010-2011
*
*  Description:
*  Create By Derek Zhan at 2010-2011 
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
    public class TimeAccounting : Identifier
    {
       public TimeAccounting()
       {
           
       }

       [XmlElement(ElementName = "TimeAccountingGroup")] 
       public TimeAccountingGroup TimeAccountingGroup;

       [XmlElement(ElementName = "TimeAccountingType")] 
       public TimeAccountingType TimeAccountingType;

       [XmlElement(ElementName = "startTime")] 
       public string startTime;

       [XmlElement(ElementName = "endTime")]
       public string endTime;

       [XmlElement(ElementName = "duration")]
       public string duration;

      [XmlElement(ElementName = "reference")]
       public string reference;

      [XmlAttribute(AttributeName = "action")]
      public string action;
    }
}
