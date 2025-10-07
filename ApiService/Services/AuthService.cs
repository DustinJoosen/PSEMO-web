using ApiService.Interfaces;
using Infrastructure.Dtos;
using System.Text;
using System.Text.Json;

namespace ApiService.Services
{
    public class AuthService : CrudAPIService, IAuthService
    {
        public AuthService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token.</returns>
        public async Task<string?> Login(LoginDTO login)
        {
            string? response = await this.Post<LoginDTO>("api/auth/login", login);
            return response;
        }

        /// <summary>
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token.</returns>
        public async Task<string?> Register(RegistrationDTO registration)
        {
            string? response = await this.Post<RegistrationDTO>("api/auth/register", registration);
            return response;
        }

    }
}
