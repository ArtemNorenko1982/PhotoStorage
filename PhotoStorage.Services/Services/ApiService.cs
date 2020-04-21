using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoStorage.Common;
using PhotoStorage.Contracts;
using PhotoStorage.Services.Interfaces;

namespace PhotoStorage.Services.Services
{
    public class ApiService : IApiService
    {
        private readonly IConnectionService _connectionService;
        
        public ApiService(IConnectionService connectionService)
        {
            this._connectionService = connectionService;
        }

        public async Task<IEnumerable<PhotoItem>> LoadPhotoFromServer()
        {
            IEnumerable<PhotoItem> result = new List<PhotoItem>();
            var client = new HttpClient
            {
                BaseAddress = new Uri(RemoteApiServerConstants.BaseApiServer)
            };

            var loginResult = await LogIn();
            if (loginResult.IsSuccess)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);
                var response = await client.GetAsync($"/{RemoteApiServerConstants.BaseApiImagePath}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<IEnumerable<PhotoItem>>(data);
                }
            }

            return result;
        }

        #region Private Methods

        private async Task<bool> CheckServerAvailabilityAsync()
        {
            var testConnectionResponse = await _connectionService.TestConnection();
            return testConnectionResponse.StatusCode == HttpStatusCode.OK;
        }

        private async Task<AuthResult> LogIn()
        {
            var logInResult = new AuthResult();
            if (await CheckServerAvailabilityAsync())
            {
                logInResult = await _connectionService.TryLogin();
            }
            
            return logInResult;
        }

        #endregion
    }
}
