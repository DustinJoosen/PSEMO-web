using ApiService.Interfaces;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public class AuthService : IAuthService
    {
        private HttpClient _client;

        private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public AuthService(HttpClient client)
        {
            this._client = client;
        }

        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token.</returns>
        public async Task<string?> Login(LoginDTO login)
        {
            try
            {
                var json = JsonSerializer.Serialize(login, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._client.PostAsync("api/auth/login", content);

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
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token.</returns>
        public async Task<string?> Register(RegistrationDTO registration)
        {
            try
            {
                var json = JsonSerializer.Serialize(registration, this._jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._client.PostAsync("api/auth/register", content);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }

    }
}
