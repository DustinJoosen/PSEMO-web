using ApiService.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace ApiService.Services
{
    public class AuthService : CrudAPIService, IAuthService
    {
        public AuthService(HttpClient client, ILocalStorageJwtService jwtService) : base(client, jwtService)
        {
        }

        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token if successful. Otherwise the error message.</returns>
        public async Task<CrudApiServiceResponse?> Login(LoginDTO login)
        {
            var response = await this.Post<LoginDTO>("api/auth/login", login);
            return response;
        }

        /// <summary>
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token if successful. Otherwise the error message.</returns>
        public async Task<CrudApiServiceResponse?> Register(RegistrationDTO registration)
        {
            var response = await this.Post<RegistrationDTO>("api/auth/register", registration);
            return response;
        }

        public async Task<CrudApiServiceResponse?> WhoAmI()
        {
            var response = await this.Get("/api/auth/who-am-i");
            return response;
        }
    }
}
