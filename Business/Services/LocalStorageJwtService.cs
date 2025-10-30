using Blazored.LocalStorage;
using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LocalStorageJwtService : ILocalStorageJwtService
    {
        private readonly ILocalStorageService _localStorageService;
        public LocalStorageJwtService(ILocalStorageService localStorageService)
        {
            this._localStorageService = localStorageService;
        }

        public async Task<string?> Get() =>
            await this._localStorageService.GetItemAsStringAsync("JWT");

        public async Task<bool> Has() =>
            await this._localStorageService.ContainKeyAsync("JWT");

        public async Task Remove() =>
            await this._localStorageService.RemoveItemAsync("JWT");

        public async Task Set(string val) =>
            await this._localStorageService.SetItemAsStringAsync("JWT", val);
    }
}
