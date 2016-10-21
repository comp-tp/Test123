using System;

// TODO:
// This class does not belong to this project.
// It comes from the Dev subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    [Serializable]
    public partial class AppModel
    {
        public const string AGENCY_APP = "Agency App";
        public const string CITIZEN_APP = "Citizen App";
        public enum AppTypes { 
            AgencyApp,
            CitizenApp
        }

        public Guid Id { get; set; }
        public Nullable<Guid> DevId { get; set; }

        public String AppName { get; set; }
        public int AppType { get; set; }

        public String AppId { get; set; }        
        public String Company { get; set; }

        public String Description { get; set; }
        public Nullable<Int32> Status { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public String LastUpdatedBy { get; set; }
        public String CreatedBy { get; set; }
        public String Keep1 { get; set; }
        public String Keep2 { get; set; }

        public Nullable<Int32> Stage { get; set; }
        public string SecretCode { get; set; }
    }
}
