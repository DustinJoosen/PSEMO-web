using Business.Services.Interfaces;
using Infrastructure.Dtos;
using System.Text;
using System.Text.Json;

namespace Business.Services
{
    public class AuthService : RestApiService, IAuthService
    {
        public AuthService(HttpClient client, ILocalStorageJwtService jwtService) : base(client, jwtService)
        {
        }

        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token if successful. Otherwise the error message.</returns>
        public async Task<RestApiServiceResponse?> Login(LoginDTO login)
        {
            var response = await this.Post<LoginDTO>("api/auth/login", login);
            return response;
        }

        /// <summary>
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token if successful. Otherwise the error message.</returns>
        public async Task<RestApiServiceResponse?> Register(RegistrationDTO registration)
        {
            var response = await this.Post<RegistrationDTO>("api/auth/register", registration);
            return response;
        }

        public async Task<RestApiServiceResponse?> WhoAmI()
        {
            var response = await this.Get("/api/auth/who-am-i");
            return response;
        }
    }
}
