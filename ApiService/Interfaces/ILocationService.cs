using ApiService.Services;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ILocationService
    {

        /// <summary>
        /// Returns a list of all locations.
        /// </summary>
        /// <returns>List of locations.</returns>
        Task<List<LocationDTO>?> Get();
    }
}
