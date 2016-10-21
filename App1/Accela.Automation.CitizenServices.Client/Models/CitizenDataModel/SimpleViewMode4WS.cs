/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: simpleViewModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: simpleViewModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\grady.lu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class SimpleViewModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GFilterScreenPermissionModel4WS permissionModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int screenHeight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int screenWidth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sectionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleViewElementModel4WS[] simpleViewElements { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int sizeUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string labelLayoutType { get; set; }}
}
