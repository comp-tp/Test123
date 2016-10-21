using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Images;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IImageBusinessEntity : IBusinessEntity
    {
        void AddImages(List<Image> imageModels);
    }
}
