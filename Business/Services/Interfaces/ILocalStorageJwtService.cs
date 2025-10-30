using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ILocalStorageJwtService
    {
        /// <summary>
        /// Gets the JWT token stored in the localstorage.
        /// </summary>
        /// <returns>The found JWT token.</returns>
        Task<string?> Get();

        /// <summary>
        /// Sets the JWT token stored in the localstorage.
        /// </summary>
        /// <param name="val">Value to set.</param>
        Task Set(string val);

        /// <summary>
        /// Checks if there is a JWT token in the localstorage, aka if you are logged in.
        /// </summary>
        /// <returns>Boolean indicating presence.</returns>
        Task<bool> Has();

        /// <summary>
        /// Removes the JWT token, essentially logging out.
        /// </summary>
        Task Remove();
    }
}
