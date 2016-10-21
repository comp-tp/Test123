/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GridViewColumnVisible.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GUITextModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <summary>
    /// The GridViewColumnVisible model.
    /// </summary>
    [DataContract]
    public partial class GridViewColumnVisible
    {
        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether is visible
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public bool Visible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the column width
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fixed width
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string FixWidth
        {
            get;
            set;
        }
    }
}
