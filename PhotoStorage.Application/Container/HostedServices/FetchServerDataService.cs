using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Hosting;
using PhotoStorage.Common;
using PhotoStorage.Services.Interfaces;
using SystemTimer = System.Timers.Timer;

namespace PhotoStorage.Application.Container.HastedServices
{
    /// <summary>
    /// Serves for purpose to fetch server data in back ground thread
    /// </summary>
    public class FetchServerDataService : IHostedService
    {
        #region Fields and Injected Services

        private readonly SystemTimer _timer;
        private readonly IApiService _baseApiService;
        
        #endregion

        public FetchServerDataService(
            IApiService baseApiService)
        {
            _timer = new SystemTimer();
            this._baseApiService = baseApiService;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer.Elapsed += async (obj, e) => await OnTimerElapsed(obj, e);
            _timer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Stop();
            return Task.CompletedTask;
        }

        #region Private Methods

        private async Task OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var isSuccess = await LoadServerDataAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        private async Task<bool> LoadServerDataAsync()
        {
            var serverData = (await _baseApiService.LoadPhotoFromServer()).ToList();
            if (serverData.Any())
            {
                if (GlobalDataStorage.Photos.Any())
                {
                    GlobalDataStorage.Photos.Clear();
                }
                GlobalDataStorage.Photos = serverData;
            }

            return serverData.Any();
        }
        #endregion
    }
}
