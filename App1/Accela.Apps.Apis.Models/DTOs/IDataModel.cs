using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs
{
    public interface IDataModel
    {
        /// <summary>
        /// Emit fields. if empty or null, emit all fields.
        /// </summary>
        List<string> EmitFields
        {
            get;
            set;
        }

        /// <summary>
        /// Ignore Emit fields.
        /// </summary>
        List<string> IgnoreEmitFields
        {
            get;
            set;
        }
    }
}
