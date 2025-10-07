using ApiService.Interfaces;
using ApiService.Services;
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

        public ApiClient(HttpClient client)
        {
            this._client = client;
            if (this._client== null)
                return;

            this.AuthService = new AuthService(client);
        }

        public void Dispose()
        {
            this._client.Dispose();
        }
    }
}
