using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{
    // Summary:
    //     Defines the set of comparison operators that may be used for constructing
    //     queries.
    public static class QueryComparisons
    {
        // Summary:
        //     Represents the Equal operator.
        public const string Equal = "eq";
        //
        // Summary:
        //     Represents the Greater Than operator.
        public const string GreaterThan = "gt";
        //
        // Summary:
        //     Represents the Greater Than or Equal operator.
        public const string GreaterThanOrEqual = "ge";
        //
        // Summary:
        //     Represents the Less Than operator.
        public const string LessThan = "lt";
        //
        // Summary:
        //     Represents the Less Than or Equal operator.
        public const string LessThanOrEqual = "le";
        //
        // Summary:
        //     Represents the Not Equal operator.
        public const string NotEqual = "ne";
    }
}
