using System;

// TODO:
// This class does not belong to this project.
// It comes from the Admin subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    public class HostEnvironmentDetailModel
    {
        public Guid ID
        {
            get;
            set;
        }

        public Guid HostEnvironmentId
        {
            get;
            set;
        }

        public string ServerURL
        {
            get;
            set;
        }

        public int ServerType
        {
            get;
            set;
        }

        public int ServerStatus
        {
            get;
            set;
        }

        public string VersionNum
        {
            get;
            set;
        }

        public string Description 
        {
            get;
            set;
        }

        public DateTime? LastUpdatedDate
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }

        public string LastUpdatedBy
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }
    }
}
