using ApiService.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public class LocationService : CrudAPIService, ILocationService
    {
        public LocationService(HttpClient client, ILocalStorageJwtService jwtService) 
            : base(client, jwtService)
        {
        }

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