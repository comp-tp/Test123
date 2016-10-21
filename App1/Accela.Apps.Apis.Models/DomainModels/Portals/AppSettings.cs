using System;

// TODO:
// This class does not belong to this project.
// It comes from the Dev subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    /// <summary>
    /// App settings model class.
    /// </summary>
    public partial class AppSettings
    {
        /// <summary>
        /// ID.
        /// </summary>
        public Guid ID
        {
            get;
            set;
        }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Default value.
        /// </summary>
        public string DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// Settings Value.
        /// </summary>
        public string SettingsValue
        {
            get;
            set;
        }

        /// <summary>
        /// Settings value id.
        /// </summary>
        public Guid? SettingsValueId
        {
            get;
            set;
        }

        /// <summary>
        /// Host setting value.
        /// </summary>
        public string HostSettingValue
        {
            get;
            set;
        }

        /// <summary>
        /// Setting type.
        /// </summary>
        public string SettingType
        {
            get;
            set;
        }        

        /// <summary>
        /// Application key.
        /// </summary>
        public Guid AppKey
        {
            get;
            set;
        }

        /// <summary>
        /// Creator.
        /// </summary>
        public String CreatedBy 
        {
            get; 
            set; 
        }

        /// <summary>
        /// Created date.
        /// </summary>
        public DateTime CreatedDate
        { 
            get;
            set;
        }

        /// <summary>
        /// Updater.
        /// </summary>
        public String UpdatedBy
        {
            get;
            set;
        }
        
        /// <summary>
        /// Updated date.
        /// </summary>
        public DateTime UpdatedDate
        {
            get;
            set;
        } 
        
    }
}
