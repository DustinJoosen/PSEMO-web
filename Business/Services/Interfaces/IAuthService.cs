using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token.</returns>
        Task<RestApiServiceResponse?> Login(LoginDTO login);

        /// <summary>
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token.</returns>
        Task<RestApiServiceResponse?> Register(RegistrationDTO registration);

        Task<RestApiServiceResponse?> WhoAmI();

    }
}