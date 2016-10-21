using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Images;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IImageRepository : IRepository
    {
        void AddImages(List<Image> imageModels);
    }
}
