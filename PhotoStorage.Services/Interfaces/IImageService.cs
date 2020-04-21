using System.Collections.Generic;
using PhotoStorage.Contracts;

namespace PhotoStorage.Services.Interfaces
{
    public interface IImageService
    {
        PhotoItem GetItemById(string id);
        IEnumerable<PhotoItem> GetAll();
    }
}
