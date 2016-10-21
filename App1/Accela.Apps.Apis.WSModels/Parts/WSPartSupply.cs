using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partSupply")]
    public class WSPartSupply : WSDataModel
    {
        /// <summary>
        /// Gets or sets the supply id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the supply display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the supply locationName.
        /// </summary>
        [DataMember(Name = "locationName", EmitDefaultValue = false)]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the supply locationSeq.
        /// </summary>
        [DataMember(Name = "locationSeq", EmitDefaultValue = false)]
        public int LocationSeq { get; set; }

        /// <summary>
        /// Convert PartSupplyModel to WSPartSupply.
        /// </summary>
        /// <param name="partSupplyModel">partSupplyModel.</param>
        /// <returns>WSPartSupply.</returns>
        public static WSPartSupply FromEntityModel(PartSupplyModel partSupplyModel)
        {
            if (partSupplyModel != null)
            {
                return new WSPartSupply()
                {
                    Id = partSupplyModel.Identifier,
                    Display = partSupplyModel.Display,
                    LocationName = partSupplyModel.LocationName,
                    LocationSeq = partSupplyModel.LocationSeq
                };
            }

            return null;
        }

        /// <summary>
        /// Convert PartSupplyModel list to WSPartSupply list.
        /// </summary>
        /// <param name="partSupplyModels">partSupplyModels.</param>
        /// <returns>WSPartSupply list.</returns>
        public static List<WSPartSupply> FromEntityModels(List<PartSupplyModel> partSupplyModels)
        {
            if (partSupplyModels != null && partSupplyModels.Count > 0)
            {
                var wsSupplyList = new List<WSPartSupply>();
                foreach (var partSupplyModel in partSupplyModels)
                {
                    wsSupplyList.Add(FromEntityModel(partSupplyModel));
                }
                return wsSupplyList;
            }
            return null;
        }


        /// <summary>
        /// convert wsModel to bizModel
        /// </summary>
        /// <param name="wsPartSupplies"></param>
        /// <returns></returns>
        internal static List<PartSupplyModel> ToEntityModels(List<WSPartSupply> wsPartSupplies)
        {
             
            if(wsPartSupplies!=null)
            {
                var supplyModels = new List<PartSupplyModel>();
                foreach (var supply in wsPartSupplies)
                {
                    supplyModels.Add(new PartSupplyModel()
                                         {
                                             Identifier = supply.Id,
                                             Display = supply.Id,
                                             LocationName = supply.LocationName,
                                             LocationSeq = supply.LocationSeq
                                         });
                }

                return supplyModels;
            }
            return null;
        }
    }
}
