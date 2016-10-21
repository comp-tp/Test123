using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface ICoordinateRepository : IRepository
    {
        /// <summary>
        /// Saves the coordinates to storage.
        /// </summary>
        /// <param name="coordinateModels">The coordinate models.</param>
        void SaveCoordinatesToStorage(CoordinateModel[] coordinateModels);

        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns></returns>
        CoordinateModel[] GetCoordinates(string[] addresses, string outSR = "4326", bool cacheEnabled = true);

        CoordinateModel GetCoordinate(AddressModel address, string outSR = "4326");

        void SaveRecordCoordinate(GeoCoordinateModel recordCoordinate);

        List<GeoCoordinateModel> GetRecordIdsByBBox(BBox bbox);

        List<GeoCoordinateModel> GlobalEntityIdsWithinRange(GeoSearchRangeModel range);

        List<RecordGeoModel> GetRecordsByBBox(BBox bbox, Guid civicId, string environment, int offset, int limit);

        int GetRecordsCountByBBox(BBox bbox, Guid civicId, string environment);

        List<RecordGeoModel> GetRecordsByCircle(GeoSearchRangeModel circle, Guid civicId, string environment, int offset, int limit);

        int GetRecordsCountByCircle(GeoSearchRangeModel circle, Guid civicId, string environment);
    }
}
