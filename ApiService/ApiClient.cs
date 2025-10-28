using ApiService.Interfaces;
using ApiService.Services;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService
{
    public class ApiClient : IDisposable
    {
        private HttpClient _client;

        public IAuthService AuthService { get; set; }
        public IFilterService FilterService { get; set; }

        public ApiClient(HttpClient client, ILocalStorageJwtService localStorageJwtService)
        {
            this._client = client;
            if (this._client== null)
                return;

            this.AuthService = new AuthService(client, localStorageJwtService);
            this.FilterService = new FilterService(client, localStorageJwtService);
        }

        public void Dispose()
        {
            this._client.Dispose();
        }
    }
}
