using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{

    /// <summary>
    /// Defines the set of Boolean operators for constructing queries.
    /// </summary>
    public static class TableOperators
    {
        /// <summary>
        /// Represents the And operator.
        /// </summary>
        public const string And = "and";

        /// <summary>
        /// Represents the Not operator.
        /// </summary>
        public const string Not = "not";

        /// <summary>
        /// Represents the Or operator.
        /// </summary>
        public const string Or = "or";
    }
}
