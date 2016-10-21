using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels
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
