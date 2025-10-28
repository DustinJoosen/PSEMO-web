using ApiService.Services;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IFilterService
    {
        Task<List<AllFiltersDTO>?> GetFilters();
    }
}
