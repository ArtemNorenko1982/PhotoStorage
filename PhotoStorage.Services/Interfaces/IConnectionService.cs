using System.Net.Http;
using System.Threading.Tasks;
using PhotoStorage.Common;

namespace PhotoStorage.Services.Interfaces
{
    public interface IConnectionService
    {
        Task<HttpClient> GetActiveConnection();

        Task<AuthResult> TryLogin();

        Task<HttpResponseMessage> TestConnection();
    }
}
