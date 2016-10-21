/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificTableModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificTableModel4WS.cs 213067 2012-02-08 01:21:12Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class AppSpecificTableModel4WS : ICloneable
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificTableColumnModel4WS[] columns
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificTableField4WS[] defaultField
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInstruction
        {
            get;
            set;
        }/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resTableName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] rowIndex
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificTableField4WS[] tableField
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] tableFieldValues
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int tableIndex
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tableName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vchDispFlag
        {
            get;
            set;
        }

        #region ICloneable Members

        /// <summary>
        /// Deep clone this AppSpecificTableModel4WS object.
        /// </summary>
        /// <returns>AppSpecificTableModel4WS object.</returns>
        public object Clone()
        {
            if (null == this)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }

        #endregion
    }
}
