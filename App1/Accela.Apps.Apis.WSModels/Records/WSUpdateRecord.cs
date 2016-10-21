using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.Owners;
using Accela.Apps.Apis.WSModels.Parcels;
using Accela.Apps.Apis.WSModels.Parts;
using Accela.Apps.Apis.WSModels.RecordComments;
using Accela.Apps.Apis.WSModels.RecordContacts;
using Accela.Apps.Apis.WSModels.RecordCosts;
using Accela.Apps.Apis.WSModels.V1.WorkOrderTasks;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "updateRecord")]
    public class WSUpdateRecord : WSRecord
    {
        /// <summary>
        /// The record contact information which do not contain owner information.
        /// </summary>
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<WSContact> Contacts { get; set; }

        /// <summary>
        /// The record addresses information.
        /// </summary>
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<WSAddress> Addresses { get; set; }

        /// <summary>
        /// Owners.
        /// </summary>
        [DataMember(Name = "owners", EmitDefaultValue = false)]
        public List<WSOwner> Owners { get; set; }

        /// <summary>
        /// ASIs.
        /// </summary>
        [DataMember(Name = "asis", EmitDefaultValue = false)]
        public List<WSASI> ASIs { get; set; }

        /// <summary>
        /// ASITs.
        /// </summary>
        [DataMember(Name = "asits", EmitDefaultValue = false)]
        public List<WSASIT> ASITs { get; set; }

        /// <summary>
        /// The record parcel information
        /// </summary>
        [DataMember(Name = "parcels", EmitDefaultValue = false)]
        public List<WSParcel> Parcels { get; set; }

        /// <summary>
        /// The record comments information
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<WSRecordComment> Comments { get; set; }

        [DataMember(Name = "assets", EmitDefaultValue = false)]
        public List<WSAsset> Assets { get; set; }

        [DataMember(Name = "workOrderTasks", EmitDefaultValue = false)]
        public List<WSWorkOrderTask> WorkOrderTasks { get; set; }

        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<WSCost> Costs { get; set; }

        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<WSPart> Parts { get; set; } 

        /// <summary>
        /// Convert to the entity model.
        /// </summary>
        /// <param name="wsUpdateRecord">The ws record.</param>
        /// <returns>the entity model.</returns>
        public static RecordModel ToEntityModel(WSUpdateRecord wsUpdateRecord)
        {
            if (wsUpdateRecord != null)
            {
                var recordModel = new RecordModel();
                WSRecord.ToEntityModel(recordModel, wsUpdateRecord);
                if (wsUpdateRecord.Contacts != null && wsUpdateRecord.Contacts.Count > 0)
                {
                    var contactModels = new List<ContactModel>();
                    wsUpdateRecord.Contacts.ForEach(c => contactModels.Add(WSContact.ToEnityModel(c)));
                    recordModel.Contacts = contactModels;
                }

                if (wsUpdateRecord.Addresses != null && wsUpdateRecord.Addresses.Count > 0)
                {
                    var addressModels = new List<AddressModel>();
                    wsUpdateRecord.Addresses.ForEach(a => addressModels.Add(WSAddress.ToEntityModel(a)));
                    recordModel.Addresses = addressModels;
                }

                if (wsUpdateRecord.Owners != null && wsUpdateRecord.Owners.Count > 0)
                {
                    var contactOwnerModels = new List<ContactModel>();
                    wsUpdateRecord.Owners.ForEach(o => contactOwnerModels.Add(WSOwner.ToEntityContactModel(o)));

                    if (recordModel.Contacts == null)
                    {
                        recordModel.Contacts = new List<ContactModel>();
                    }

                    if (contactOwnerModels.Count > 0)
                    {
                        recordModel.Contacts.AddRange(contactOwnerModels.ToArray());
                    }
                }

                if (wsUpdateRecord.Parcels != null && wsUpdateRecord.Parcels.Count > 0)
                {
                    var parcels = new List<ParcelModel>();
                    wsUpdateRecord.Parcels.ForEach(p => parcels.Add(WSParcel.ToEntityModel(p)));
                    recordModel.Parcels = parcels;
                }

                if (wsUpdateRecord.ASIs != null && wsUpdateRecord.ASIs.Count > 0)
                {
                    var asis = new List<AdditionalGroupModel>();
                    wsUpdateRecord.ASIs.ForEach(a => asis.Add(WSASI.ToEntityModel(a)));
                    recordModel.AdditionalInfo = asis;
                }

                if (wsUpdateRecord.ASITs != null && wsUpdateRecord.ASITs.Count > 0)
                {
                    var asits = new List<AdditionalTableModel>();
                    wsUpdateRecord.ASITs.ForEach(a => asits.Add(WSASIT.ToEntityModel(a)));
                    recordModel.AdditionalTableInfo = asits;
                }

                if (wsUpdateRecord.Comments != null && wsUpdateRecord.Comments.Count > 0)
                {
                    var comments = new List<RecordCommentModel>();
                    wsUpdateRecord.Comments.ForEach(a => comments.Add(WSRecordComment.ToEntityModel(a)));
                    recordModel.RecordComments = comments;
                }

                if (wsUpdateRecord.Assets != null && wsUpdateRecord.Assets.Count > 0)
                {
                    var assets = new List<AssetModel>();
                    wsUpdateRecord.Assets.ForEach(x => assets.Add(WSAsset.ToEntityModel(x)));
                    recordModel.Assets = assets;
                }

                if (wsUpdateRecord.WorkOrderTasks != null && wsUpdateRecord.WorkOrderTasks.Count > 0)
                {
                    recordModel.WorkOrderTasks = new List<WorkOrderTaskModel>(wsUpdateRecord.WorkOrderTasks.Count);
                    wsUpdateRecord.WorkOrderTasks.ForEach(task => recordModel.WorkOrderTasks.Add(WSWorkOrderTask.ToEntityModel(task)));
                }

                if (wsUpdateRecord.Costs != null && wsUpdateRecord.Costs.Count > 0)
                {
                    recordModel.Costs = new List<CostModel>(wsUpdateRecord.Costs.Count);
                    wsUpdateRecord.Costs.ForEach(cost => recordModel.Costs.Add(WSCost.ToEntityModel(cost)));
                }

                if (wsUpdateRecord.Parts != null && wsUpdateRecord.Parts.Count > 0)
                {
                    recordModel.Parts = new List<PartModel>(wsUpdateRecord.Parts.Count);
                    wsUpdateRecord.Parts.ForEach(part => recordModel.Parts.Add(WSPart.ToEntityModel(part)));
                }

                return recordModel;
            }

            return null;
        }
    }
}
