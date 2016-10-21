using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Images;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Repositories.Interfaces;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ImageBusinessEntity : IImageBusinessEntity
    {
        private readonly IImageRepository imageRepository = null;

        public ImageBusinessEntity(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //public IImageRepository ImageRepository
        //{
        //    get
        //    {
        //        if (_imageRepository == null)
        //        {
        //            _imageRepository = IocContainer.Resolve<IImageRepository>();
        //        }
        //        return _imageRepository;
        //    }
        //}

        public void AddImages(List<Image> imageModels)
        {
            imageRepository.AddImages(imageModels);
        }

    }
}
