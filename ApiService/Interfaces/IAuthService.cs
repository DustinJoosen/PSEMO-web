using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Sends login DTO be be validated.
        /// </summary>
        /// <param name="login">Login data.</param>
        /// <returns>The JWT token.</returns>
        Task<string?> Login(LoginDTO login);

        /// <summary>
        /// Sends registration DTO be be registered.
        /// </summary>
        /// <param name="registration">Registration data.</param>
        /// <returns>The JWT token.</returns>
        Task<string?> Register(RegistrationDTO registration);
    }
}