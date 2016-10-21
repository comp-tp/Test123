﻿#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: District.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description:
*  Create By Daniel Shi
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
    public class District
    {
        [XmlElement(ElementName = "district", IsNullable = true)]
        public string key;
    }
}