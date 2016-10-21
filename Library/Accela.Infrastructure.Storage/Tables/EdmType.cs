﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{
    public enum EdmType
    {
        /// <summary>
        /// Represents fixed- or variable-length character data.
        /// </summary>
        String,

        /// <summary>
        /// Represents fixed- or variable-length binary data.
        /// </summary>
        Binary,

        /// <summary>
        /// Represents the mathematical concept of binary-valued logic.
        /// </summary>
        Boolean,

        /// <summary>
        /// Represents date and time.
        /// </summary>
        DateTime,

        /// <summary>
        /// Represents a floating point number with 15 digits precision that can represent values with approximate range of +/- 2.23e -308 through +/- 1.79e +308.
        /// </summary>
        Double,

        /// <summary>
        /// Represents a 16-byte (128-bit) unique identifier value.
        /// </summary>
        Guid,

        /// <summary>
        /// Represents a signed 32-bit integer value.
        /// </summary>
        Int32,

        /// <summary>
        /// Represents a signed 64-bit integer value.
        /// </summary>
        Int64,
    }
}
