using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Common;

namespace Accela.Apps.Apis.Repositories.Citizen
{
     public class ImageRepository : RepositoryBase, IImageRepository
    {
        public void AddImages(List<Accela.Apps.Apis.Models.DomainModels.Images.Image> imageModels)
        {
            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var images = FromEntityModels(imageModels);
                if (images != null && images.Count > 0)
                {
                    images.ForEach(image => objectContext.Images.Add(image));
                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        objectContext.SaveChanges();
                    });
                }
            }
        }

        private static Image FromEntityModel(Accela.Apps.Apis.Models.DomainModels.Images.Image imageModel)
        {
            if (imageModel != null)
            {
                var image = new Image();
                image.Id = Guid.NewGuid();
                if (imageModel.Id != Guid.Empty)
                {
                    image.Id = imageModel.Id;
                }
                image.BlobContainer = imageModel.BlobContainer;
                image.BlobName = imageModel.BlobName;
                image.CreatedBy = imageModel.CreatedBy;
                image.CreatedDate = imageModel.CreatedDate ?? DateTime.Now;
                image.GlobalEntityID = imageModel.GlobalEntityID;
                image.ImageURL = imageModel.ImageURL;
                image.LastUpdatedBy = imageModel.LastUpdatedBy;
                image.LastUpdatedDate = imageModel.LastUpdatedDate;
                return image;
            }

            return null;
        }

        private static List<Image> FromEntityModels(List<Accela.Apps.Apis.Models.DomainModels.Images.Image> imageModels)
        {
            var images = new List<Image>();
            if (imageModels != null && imageModels.Count > 0)
            {
                imageModels.ForEach(imgModel => images.Add(FromEntityModel(imgModel)));
            }
            return images;
        }
    }
}
