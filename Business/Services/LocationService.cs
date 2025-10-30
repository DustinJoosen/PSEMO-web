using Business.Services.Interfaces;
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LocationService : RestApiService, ILocationService
    {
        public LocationService(HttpClient client, ILocalStorageJwtService jwtService) 
            : base(client, jwtService)
        {
        }

        /// <summary>
        /// Returns a list of all locations.
        /// </summary>
        /// <returns>List of locations.</returns>
        public async Task<List<LocationDTO>?> Get()
        {
            var response = await this.Get("api/location");
            if (response == null)
                return null;

            if (!response.Succeeded)
                return null;

            return JsonSerializer.Deserialize<List<LocationDTO>>(response.Message!, this._jsonOptions);
        }
    }
}