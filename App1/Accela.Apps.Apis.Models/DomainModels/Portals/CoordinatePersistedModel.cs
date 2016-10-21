using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
//
//using Microsoft.WindowsAzure.StorageClient;

// TODO:
// This class does not belong to this project.
// Not sure what sub-system will contain this class.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    /// <summary>
    /// Coordinate Persisted Model
    /// </summary>
    public class CoordinatePersistedModel : ITableEntity
    {
        /// <summary>
        /// Gets or sets PartitionKey.
        /// </summary>
        public string PartitionKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets RowKey.
        /// the value is a MD5 value of address.
        /// </summary>
        public string RowKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude
        {
            get;
            set;
        }

        public DateTimeOffset Timestamp
        {
            get;
            set;
        } 
    }

    /// <summary>
    /// Coordinate Persisted Model Comparer
    /// </summary>
    public class CoordinatePersistedModelComparer : IEqualityComparer<CoordinatePersistedModel>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param>
        /// <param name="y">The second object of type <paramref name="T"/> to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(CoordinatePersistedModel x, CoordinatePersistedModel y)
        {
            bool result = false;

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y))
            {
                result = true;
            }
            else if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            {
                result = false;
            }
            else
            {
                result = x.PartitionKey == y.PartitionKey && x.RowKey == y.RowKey;
            }

            return result;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(CoordinatePersistedModel model)
        {
            int result = 0;

            if (Object.ReferenceEquals(model, null))
            {
                result = 0;
            }
            else
            {
                int hashPartitionKey = model.PartitionKey == null ? 0 : model.PartitionKey.GetHashCode();
                int hashProductCode = model.RowKey == null ? 0 : model.RowKey.GetHashCode();
                result = hashPartitionKey ^ hashProductCode;
            }

            return result;
        }
    }
}
