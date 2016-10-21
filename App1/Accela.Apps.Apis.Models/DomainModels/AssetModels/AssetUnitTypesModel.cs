using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
 
namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    [DataContract(Name="GetAssertUnitTypesModel")]
    public class AssetUnitTypesModel : DataModel, IDataModel
    {
        /// <summary>
        /// Gets or Sets the AssetUnitTypesModel Key.
        /// </summary>
        [DataMember(Name ="id",EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// Gets or Sets the IdentifierDisplay.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string IdentifierDisplay;

        /// <summary>
        /// Gets or Sets the EnumerationType.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string  Type;

        /// <summary>
        /// Gets or Sets the Description.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description; 
    }
}
