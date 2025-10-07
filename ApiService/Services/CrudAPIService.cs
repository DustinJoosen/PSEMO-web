using ApiService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public abstract class CrudAPIService : ICrudAPIService
    {
        protected HttpClient _client;
        protected JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public CrudAPIService(HttpClient client)
        {
            this._client = client;
        }

        /// <summary>
        /// Sends a request for an entity to be retrieved.
        /// </summary>
        /// <param name="uri">Uri to send the get request to.</param>
        /// <returns>HTTP response.</returns>
        public virtual async Task<string?> Get(string uri)
        {
            try
            {
                var response = await this._client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends a request for an entity to be created.
        /// </summary>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <param name="uri">Uri to send the post request to.</param>
        /// <param name="payload">Payload to send along the request.</param>
        /// <returns>HTTP response.</returns>

        public virtual async Task<string?> Post<T>(string uri, T payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await this._client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends a request for an entity to be updated.
        /// </summary>
        /// <param name="uri">Uri to send the put request to.</param>
        /// <param name="payload">Payload to send along the request.</param>
        /// <returns>The updated entity.</returns>
        public virtual async Task<string?> Put<T>(string uri, T payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._client.PutAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends a request for an entity to be deleted.
        /// </summary>
        /// <param name="uri">Uri to send the delete request to.</param>
        /// <returns>Boolean indicating success</returns>
        public virtual async Task<bool> Delete(string uri)
        {
            try
            {
                var response = await this._client.DeleteAsync(uri);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
