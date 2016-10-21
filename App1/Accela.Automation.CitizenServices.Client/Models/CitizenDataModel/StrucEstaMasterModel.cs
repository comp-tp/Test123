#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: StrucEstaMasterModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: StrucEstaMasterModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StructureEstablishmentModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class StrucEstaMasterModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double baths { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool bathsSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double beds { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool bedsSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double coordinator_X { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool coordinator_XSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double coordinator_Y { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool coordinator_YSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dateBuilt { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dateBuiltSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDateBuilt { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDateBuiltSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endStatusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endStatusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double floor { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool floorSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double floorArea_1st { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool floorArea_1stSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double frontDimension { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool frontDimensionSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string garage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double height { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool heightSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string landUseValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double numberRooms { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool numberRoomsSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double parcelsAreas { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool parcelsAreasSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double percentEmployees { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool percentEmployeesSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double percentResidentialUnits { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool percentResidentialUnitsSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int percentStructure { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool percentStructureSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int percentUsed { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool percentUsedSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pool { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double rearDimension { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool rearDimensionSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double sideDimension1 { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool sideDimension1Specified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double sideDimension2 { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool sideDimension2Specified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sourceSeqNumber { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool sourceSeqNumberSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime statusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool statusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long strucEstaSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool strucEstaSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalArea { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalAreaSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalFloorArea { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalFloorAreaSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalFloors { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalFloorsSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
