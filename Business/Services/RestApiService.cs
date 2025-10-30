using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Services.Interfaces;

namespace Business.Services
{
    public record HttpResponseStatusMessage(int StatusCode, string Message);
    public record RestApiServiceResponse(string? Message, bool Succeeded);

    public abstract class RestApiService : IRestApiService
    {
        protected HttpClient _client;
        protected ILocalStorageJwtService _localStorageJwtService;

        protected JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public RestApiService(HttpClient client, ILocalStorageJwtService localStorageJwtService)
        {
            this._client = client;
            this._localStorageJwtService = localStorageJwtService;
        }

        /// <summary>
        /// Sends a request for an entity to be retrieved.
        /// </summary>
        /// <param name="uri">Uri to send the get request to.</param>
        /// <returns>HTTP response. Message and succeeded</returns>
        public virtual async Task<RestApiServiceResponse?> Get(string uri)
        {
            try
            {
                // Get and set the authorization token.
                var jwt = await this._localStorageJwtService.Get();
                if (jwt != null)
                    this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                var response = await this._client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                var message = await response.Content.ReadAsStringAsync();

                // If invalid, grab the message out of the error.
                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonSerializer.Deserialize<HttpResponseStatusMessage>(message, this._jsonOptions);
                    message = error!.Message;
                }

                return new(
                    Message: message,
                    Succeeded: response.IsSuccessStatusCode
                );
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
        /// <returns>HTTP response. Message and succeeded</returns>

        public virtual async Task<RestApiServiceResponse?> Post<T>(string uri, T payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Get and set the authorization token.
                var jwt = await this._localStorageJwtService.Get();
                if (jwt != null)
                    this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                var response = await this._client.PostAsync(uri, content);
                var message = await response.Content.ReadAsStringAsync();

                // If invalid, grab the message out of the error.
                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonSerializer.Deserialize<HttpResponseStatusMessage>(message, this._jsonOptions);
                    message = error!.Message;
                }

                return new(
                    Message: message,
                    Succeeded: response.IsSuccessStatusCode
                );
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
        /// <returns>HTTP response. Message and succeeded</returns>
        public virtual async Task<RestApiServiceResponse?> Put<T>(string uri, T payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Get and set the authorization token.
                var jwt = await this._localStorageJwtService.Get();
                if (jwt != null)
                    this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                var response = await this._client.PutAsync(uri, content);
                var message = await response.Content.ReadAsStringAsync();

                // If invalid, grab the message out of the error.
                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonSerializer.Deserialize<HttpResponseStatusMessage>(message, this._jsonOptions);
                    message = error!.Message;
                }

                return new(
                    Message: message,
                    Succeeded: response.IsSuccessStatusCode
                );
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
