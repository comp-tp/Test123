using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.Location;
using Accela.Apps.Apis.WSModels.Owners;
using Accela.Apps.Apis.WSModels.Parcels;
using Accela.Apps.Apis.WSModels.Parts;
using Accela.Apps.Apis.WSModels.RecordComments;
using Accela.Apps.Apis.WSModels.RecordContacts;
using Accela.Apps.Apis.WSModels.RecordCosts;
using Accela.Apps.Apis.WSModels.V1.WorkOrderTasks;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "createRecord")]
    public class WSCreateRecord : WSRecordBase
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

        [DataMember(Name = "gisObjects", EmitDefaultValue = false)]
        public List<WSGISObject> GISObjects { get; set; }


        #region the properities from work order template
        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<WSCost> Costs { get; set; }

        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<WSPart> Parts { get; set; }

        [DataMember(Name = "workOrderTasks", EmitDefaultValue = false)]
        public List<WSWorkOrderTask> WorkOrderTasks { get; set; }
        #endregion

        [DataMember(Name = "assets", EmitDefaultValue = false)]
        public List<WSAsset> Assets { get; set; }

        /// <summary>
        /// Convert WSCreateRecord to RecordModel.
        /// </summary>
        /// <param name="wsCreateRecord">WSCreateRecord.</param>
        /// <returns>RecordModel.</returns>
        public static RecordModel ToEntityModel(WSCreateRecord wsCreateRecord)
        {
            if (wsCreateRecord != null)
            {
                var recordModel = new RecordModel();
                WSRecordBase.ToEntityModel(recordModel, wsCreateRecord);

                if (wsCreateRecord.Contacts != null && wsCreateRecord.Contacts.Count > 0)
                {
                    var contactModels = new List<ContactModel>();
                    wsCreateRecord.Contacts.ForEach(c => contactModels.Add(WSContact.ToEnityModel(c)));
                    recordModel.Contacts = contactModels;
                }

                if (wsCreateRecord.Addresses != null && wsCreateRecord.Addresses.Count > 0)
                {
                    var addressModels = new List<AddressModel>();
                    wsCreateRecord.Addresses.ForEach(a => addressModels.Add(WSAddress.ToEntityModel(a)));
                    recordModel.Addresses = addressModels;
                }

                if (wsCreateRecord.Owners != null && wsCreateRecord.Owners.Count > 0)
                {
                    var contactOwnerModels = new List<ContactModel>();
                    wsCreateRecord.Owners.ForEach(o => contactOwnerModels.Add(WSOwner.ToEntityContactModel(o)));

                    if (recordModel.Contacts == null)
                    {
                        recordModel.Contacts = new List<ContactModel>();
                    }

                    if (contactOwnerModels.Count > 0)
                    {
                        recordModel.Contacts.AddRange(contactOwnerModels.ToArray());
                    }
                }

                if (wsCreateRecord.Parcels != null && wsCreateRecord.Parcels.Count > 0)
                {
                    var parcels = new List<ParcelModel>();
                    wsCreateRecord.Parcels.ForEach(p => parcels.Add(WSParcel.ToEntityModel(p)));
                    recordModel.Parcels = parcels;
                }

                if (wsCreateRecord.ASIs != null && wsCreateRecord.ASIs.Count > 0)
                {
                    var asis = new List<AdditionalGroupModel>();
                    wsCreateRecord.ASIs.ForEach(a => asis.Add(WSASI.ToEntityModel(a)));
                    recordModel.AdditionalInfo = asis;
                }

                if (wsCreateRecord.ASITs != null && wsCreateRecord.ASITs.Count > 0)
                {
                    var asits = new List<AdditionalTableModel>();
                    wsCreateRecord.ASITs.ForEach(a => asits.Add(WSASIT.ToEntityModel(a)));
                    recordModel.AdditionalTableInfo = asits;
                }

                if (wsCreateRecord.Comments != null && wsCreateRecord.Comments.Count > 0)
                {
                    var comments = new List<RecordCommentModel>();
                    wsCreateRecord.Comments.ForEach(a => comments.Add(WSRecordComment.ToEntityModel(a)));
                    recordModel.RecordComments = comments;
                }

                if (wsCreateRecord.Owners != null && wsCreateRecord.Owners.Count > 0)
                {
                    var owners = new List<OwnerModel>();
                    wsCreateRecord.Owners.ForEach(owner => owners.Add(WSOwner.ToEntityModel(owner)));
                    recordModel.Owners = owners;
                }

                if (wsCreateRecord.GISObjects != null && wsCreateRecord.GISObjects.Count > 0)
                {
                    var gisObjects = new List<GISObjectModel>();
                    wsCreateRecord.GISObjects.ForEach(gis => gisObjects.Add(WSGISObject.ToEntityModel(gis)));
                    recordModel.GISObjects = gisObjects;
                }

                if (wsCreateRecord.Costs != null && wsCreateRecord.Costs.Count > 0)
                {
                    var costs = new List<CostModel>();
                    wsCreateRecord.Costs.ForEach(x =>
                    {
                        if (String.IsNullOrEmpty(x.EntityState))
                        {
                            x.EntityState = WSEntityState.ADDED;
                        }
                        costs.Add(WSCost.ToEntityModel(x));
                    });
                    recordModel.Costs = costs;
                }

                if (wsCreateRecord.Parts != null && wsCreateRecord.Parts.Count > 0)
                {
                    var parts = new List<PartModel>();
                    wsCreateRecord.Parts.ForEach(x =>
                    {
                        if (String.IsNullOrEmpty(x.EntityState))
                        {
                            x.EntityState = WSEntityState.ADDED;
                        }
                        parts.Add(WSPart.ToEntityModel(x));
                    });
                    recordModel.Parts = parts;
                }

                if (wsCreateRecord.WorkOrderTasks != null && wsCreateRecord.WorkOrderTasks.Count > 0)
                {
                    var workorderTasks = new List<WorkOrderTaskModel>();
                    wsCreateRecord.WorkOrderTasks.ForEach(x => workorderTasks.Add(WSWorkOrderTask.ToEntityModel(x)));
                    recordModel.WorkOrderTasks = workorderTasks;
                }

                if (wsCreateRecord.Assets != null && wsCreateRecord.Assets.Count > 0)
                {
                    var assets = new List<AssetModel>();
                    wsCreateRecord.Assets.ForEach(x => assets.Add(WSAsset.ToEntityModel(x)));
                    recordModel.Assets = assets;
                }

                return recordModel;
            }

            return null;
        }
    }
}
