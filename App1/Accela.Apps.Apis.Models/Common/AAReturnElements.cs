using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.Common
{
    /// <summary>
    /// AA return element constant.
    /// used to filter some results.
    /// most filters are used in AA V7.0 or above, some are used in AA V7.1 or above.
    /// </summary>
    public static class AAReturnElements
    {
        /// <summary>
        /// used to filter inspection results.
        /// </summary>
        public static class Inspection
        {
            /// <summary>
            /// It indicates that only Inspection Basic information and CAP basic information wiil be returned.
            /// </summary>
            public const string Basic = "Basic";

            /// <summary>
            /// It indicates that all information, including Inspection and CAP information (Including APO…etc), wiil be returned.
            /// </summary>
            public const string All = "All";

            /// <summary>
            /// It indicates that only Inspection Basic information wiil be returned.
            /// </summary>
            public const string Minimum = "Minimum";

            /// <summary>
            /// It indicates that only Inspection information (Inspection Basic info, Inspection Addresses, Inspection GuideSheet, Inspection GIS Object), Cap id, Cap Conditions and Hold, wiil be returned.
            /// </summary>
            public const string CAPIDs = "CAPIDs";

            /// <summary>
            /// It indicates that only Inspection Basic information and CAP basic information wiil be returned.
            /// for the versions prior to V7.2, the filter will return all inspection information.
            /// So, the filter should be used with other filter, for examples, use with basic filter.
            /// </summary>
            public const string Departments = "Departments";
        }

        /// <summary>
        /// used to filter record results.
        /// </summary>
        public static class Record
        {
            /// <summary>
            /// It indicates that only Record Basic Information wiil be returned.
            /// </summary>
            public const string Basic = "Basic";

            /// <summary>
            /// It indicates that All Record Information wiil be returned.
            /// </summary>
            public const string All = "All";

            /// <summary>
            /// It indicates that only Record Basic Information & Addresses wiil be returned.
            /// </summary>
            public const string Addresses = "Addresses";

            /// <summary>
            /// It indicates that only Record Basic Information & Parcels wiil be returned.
            /// </summary>
            public const string Parcels = "Parcels";

            /// <summary>
            /// It indicates that only Record Basic Information & Conditions wiil be returned.
            /// </summary>
            public const string ConditionsAndHolds = "Conditions/Holds";

            /// <summary>
            /// It indicates that only Record Basic Information & Contacts wiil be returned.
            /// </summary>
            public const string Contacts = "Contacts";

            /// <summary>
            /// It indicates that only Record Basic Information & ASI&ASIT wiil be returned.
            /// </summary>
            public const string AdditionalInformation = "AdditionalInformation";

            /// <summary>
            /// It indicates that only Record Basic Information & GIS wiil be returned.
            /// </summary>
            public const string GISObjects = "GISObjects";

            /// <summary>
            /// It indicates that only Record Basic Information & Costs wiil be returned.
            /// </summary>
            public const string Costings = "Costings";

            /// <summary>
            /// It indicates that only Record Basic Information & Assets wiil be returned.
            /// </summary>
            public const string Assets = "Assets";

            /// <summary>
            /// It indicates that only Record Basic Information & Parts wiil be returned.
            /// </summary>
            public const string Parts = "Parts";

            /// <summary>
            /// It indicates that only Record Basic Information & Comments wiil be returned.
            /// </summary>
            public const string Comments = "Comments";

            #region only apply to AA V7.1&7.2 or above

            /// <summary>
            /// It should be used with AdditionalInformation, otherwise All Record Information wiil be returned.
            /// It indicates that only Record Basic Information & DrillDown wiil be returned.
            /// </summary>
            public const string DrillDown = "DrillDown";

            /// <summary>
            /// It indicates that only Record Basic Information & ParcelIDs wiil be returned.
            /// </summary>
            public const string ParcelIDs = "ParcelIDs";

            /// <summary>
            /// It indicates that only Record Basic Information & Activity wiil be returned.
            /// </summary>
            public const string Activity = "Activity";

            /// <summary>
            /// It should be used with ConditionsAndHolds, otherwise All Record Information wiil be returned.
            /// It indicates that only Record Basic Information & ConditionTemplate wiil be returned.
            /// </summary>
            public const string ConditionTemplate = "ConditionTemplate";

            /// <summary>
            /// It should be used with Addresses, otherwise All Record Information wiil be returned.
            /// It indicates that only Record Basic Information & AddressTemplate wiil be returned.
            /// </summary>
            public const string AddressTemplate = "AddressTemplate";

            /// <summary>
            /// It should be used with Contacts, otherwise All Record Information wiil be returned.
            /// It indicates that only Record Basic Information & PeopleTemplate wiil be returned.
            /// </summary>
            public const string PeopleTemplate = "PeopleTemplate";
            #endregion
        }
    }
}