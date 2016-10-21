using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Services.Attributes
{
    /// <summary>
    /// APIActionInfo attribute. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class APIActionInfoAttribute : Attribute
    {
        /// <summary>
        /// Applicability both. 
        /// </summary>
        public const string APPLICABILITY_BOTH = "All";

        /// <summary>
        /// Applicability civc. 
        /// </summary>
        public const string APPLICABILITY_CIVIC = "Citizen";//"Civic Engagement App";

        /// <summary>
        /// Applicability agency.
        /// </summary>
        public const string APPLICABILITY_AGENCY = "Agency";//"Agency Productivity App";           

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Applicability.
        /// </summary>
        public string Applicability { get;set;}

        /// <summary>
        /// Description.
        /// </summary>
        public string Description{get;set;}

        /// <summary>
        /// Note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// APIActionInfoAttribute.
        /// </summary>
        public APIActionInfoAttribute() { }

        /// <summary>
        /// APIActionInfoAttribute constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="applicability">Applicability.</param>
        /// <param name="description">Description.</param>
        public APIActionInfoAttribute(string name, string applicability, string description)
        {            
            this.Name = Name;
            this.Applicability = applicability;
            this.Description = description;
        }
    }
}
