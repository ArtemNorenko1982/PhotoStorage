using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoStorage.Common;
using PhotoStorage.Services.Interfaces;

namespace PhotoStorage.Services.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "23567b218376f79d9415" ;

        public ConnectionService()
        {
            this._httpClient = new HttpClient{BaseAddress = new Uri(RemoteApiServerConstants.BaseApiServer)};
        }

        public Task<HttpClient> GetActiveConnection()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> TryLogin()
        {
            //TODO Add login + auth logic
            return await Authorize();
        }

        public async Task<HttpResponseMessage> TestConnection()
        {
            return await _httpClient.GetAsync(RemoteApiServerConstants.BaseApiAuthPath);
        }

        #region Private Methods

        private async Task<AuthResult> Authorize()
        {
            AuthResult result = new AuthResult();
            var content = JsonConvert.SerializeObject(new StaticRequestContent());
            var response = await _httpClient.PostAsync(RemoteApiServerConstants.BaseApiAuthPath, new StringContent(content, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<AuthResult>(data);
            }

            return result;
        }

        #endregion
    }
}
