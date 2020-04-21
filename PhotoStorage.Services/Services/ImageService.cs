using System.Collections.Generic;
using System.Linq;
using PhotoStorage.Common;
using PhotoStorage.Contracts;
using PhotoStorage.Services.Interfaces;

namespace PhotoStorage.Services.Services
{
    public class ImageService : IImageService
    {
        public PhotoItem GetItemById(string id)
        {
            return GlobalDataStorage.Photos.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<PhotoItem> GetAll()
        {
            return GlobalDataStorage.Photos;
        }
    }
}
