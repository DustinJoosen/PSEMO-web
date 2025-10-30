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
    public class FilterService : RestApiService, IFilterService
    {
        public FilterService(HttpClient client, ILocalStorageJwtService localStorageJwtService) : base(client, localStorageJwtService)
        {
        }

        public async Task<List<AllFiltersDTO>?> GetFilters()
        {
            var response = await this.Get("api/filter");
            if (response == null || !response.Succeeded)
                return null;

            return JsonSerializer.Deserialize<List<AllFiltersDTO>>(response.Message!, this._jsonOptions);
        }
    }
}
