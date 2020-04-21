using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoStorage.Contracts;

namespace PhotoStorage.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<PhotoItem>> LoadPhotoFromServer();
    }
}
