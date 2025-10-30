using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IRestApiService
    {
        /// <summary>
        /// Sends a request for an entity to be retrieved.
        /// </summary>
        /// <param name="uri">Uri to send the get request to.</param>
        /// <returns>HTTP response.</returns>
        Task<RestApiServiceResponse?> Get(string uri);

        /// <summary>
        /// Sends a request for an entity to be created.
        /// </summary>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <param name="uri">Uri to send the post request to.</param>
        /// <param name="payload">Payload to send along the request.</param>
        /// <returns>HTTP response.</returns>
        Task<RestApiServiceResponse?> Post<T>(string uri, T payload);

        /// <summary>
        /// Sends a request for an entity to be updated.
        /// </summary>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <param name="uri">Uri to send the put request to.</param>
        /// <param name="payload">Payload to send along the request.</param>
        /// <returns>HTTP response.</returns>
        Task<RestApiServiceResponse?> Put<T>(string uri, T payload);

        /// <summary>
        /// Sends a request for an entity to be deleted.
        /// </summary>
        /// <param name="uri">Uri to send the delete request to.</param>
        /// <returns>Boolean indicating success</returns>
        Task<bool> Delete(string uri);
    }
}
