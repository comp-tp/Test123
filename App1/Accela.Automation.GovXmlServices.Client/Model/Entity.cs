#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File:  Entity.cs
*
*  Accela, Inc.
*  Copyright (C): 2010
*
*  Description:
*  Create By Jaison Yang
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Entity
    {
        public Entity()
        { }

        [XmlElement(ElementName = "entityType")]
        public string entityType;

        [XmlElement(ElementName = "value")]
        public string value;
    }

    public class Entities
    {
        public Entities()
        { }

        [XmlElement(ElementName = "Entity")]
        public Entity[] Entity;
    }
}
