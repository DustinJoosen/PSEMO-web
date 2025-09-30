using ApiService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services
{
    internal class CrudAPIService<T> : ICrudAPIService<T> where T : class
    {
        private HttpClient _client;
        private readonly string _url;

        private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public CrudAPIService(HttpClient client, string url)
        {
            this._client = client;
            this._url = url;
        }

        /// <summary>
        /// Asynchronously gets all entities from the API and deserializes them.
        /// </summary>
        /// <returns>IEnumerable containing all entities.</returns>
        public async Task<IEnumerable<T>?> GetAll()
        {
            try
            {
                var response = await this._client.GetAsync(this._url, HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                    return null;

                var contentStream = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<T>>(contentStream, this._jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Asynchronously gets the specified entity from the API and deserializes it.
        /// </summary>
        /// <param name="id">Id of the entity to find.</param>
        /// <returns>Found entity, or null.</returns>
        public async Task<T?> GetById(int id)
        {
            try
            {
                var response = await this._client.GetAsync($"{this._url}/{id}", HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                    return null;

                var contentStream = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(contentStream, this._jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends a new entity to the API to be created. 
        /// </summary>
        /// <param name="dto">New entity to create.</param>
        /// <returns>The created entity</returns>
        public async Task<T?> Create(T dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._client.PostAsync(this._url, content);

                if (response.IsSuccessStatusCode)
                    return null;

                var contentStream = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(contentStream, this._jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends an existing entity to the API to be updated.
        /// Updates happen based on given Id.
        /// </summary>
        /// <param name="dto">Entity to update.</param>
        /// <returns>The updated entity.</returns>
        public async Task<T?> Update(T dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._client.PutAsync(this._url, content);

                if (response.IsSuccessStatusCode)
                    return null;

                var contentStream = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(contentStream, this._jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sends an existing entity to the API to be deleted.
        /// </summary>
        /// <param name="dto">Id of the entity to delete.</param>
        /// <returns>Boolean indicating success</returns>
        public async Task<bool> Remove(int id)
        {
            try
            {
                var response = await this._client.DeleteAsync($"{this._url}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
