using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.Citizen;
using Accela.Apps.Apis.WSModels.RecordStatus;
using Accela.Apps.Shared.FormatHelpers;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordCivicGeo
    {
        public string Id { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false, Order = 2)]
        public string Description { get; set; }

        [DataMember(Name = "user", EmitDefaultValue = false, Order = 3)]
        public WSCitizen Citizen { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false, Order = 4)]
        public WSRecordStatus RecordStatus { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false, Order = 5)]
        public string Type { get; set; }

        [DataMember(Name = "coordinateX", EmitDefaultValue = false, Order = 6)]
        public string CoordinateX { get; set; }

        [DataMember(Name = "coordinateY", EmitDefaultValue = false, Order = 7)]
        public string CoordinateY { get; set; }

        [DataMember(Name = "formattedAddress", EmitDefaultValue = false, Order = 8)]
        public string Address { get; set; }

        //[DataMember(Name = "documentIds", EmitDefaultValue = false, Order = 9)]
        //public List<string> DocumentIds { get; set; }

        [DataMember(Name = "commentsCount", Order = 10)]
        public int CommentsCount { get; set; }

        [DataMember(Name = "voteCount", Order = 11)]
        public int LikesCount { get; set; }

        [DataMember(Name = "downCount", Order = 12)]
        public int DislikesCount { get; set; }        

        [DataMember(Name = "createdDate", EmitDefaultValue = false, Order = 13)]
        public string CreatedDate { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false, Order = 14)]
        public string Creater { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string UID { get; set; }

        public string AgencyName { get; set; }

        internal static WSRecordCivicGeo FromEntityModel(RecordGeoModel record)
        {
            WSRecordCivicGeo result = new WSRecordCivicGeo();

            if (record != null)
            {
                result.UID = WSRecordBase.BuildUID(record.Agency, record.Environment, record.Id);
                result.Id = record.Id;
                result.Type = record.Type;
                result.Address = record.OneLineAddress;
                result.CoordinateX = record.CoordinateX.HasValue ? record.CoordinateX.Value.ToString() : null;
                result.CoordinateY = record.CoordinateY.HasValue ? record.CoordinateY.Value.ToString() : null;                
                result.CreatedDate = record.CreatedDate.HasValue ? Accela.Apps.Shared.FormatHelpers.DateTimeFormat.ToMetaDateTimeString(record.CreatedDate.Value) : null;
                
                result.AgencyName = record.Agency;

                if (record.User != null)
                {
                    result.Creater = record.User.FirstName + " " + record.User.LastName;
                    result.Citizen = new WSCitizen
                    {
                        CivicId = record.User.Id,
                        Email = record.User.LoginName,
                        FirstName = record.User.FirstName,
                        LastName = record.User.LastName
                    };
                }
            }

            return result;
        }
    }
}
