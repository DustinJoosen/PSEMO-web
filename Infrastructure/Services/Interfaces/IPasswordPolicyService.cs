using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IPasswordPolicyService
    {
        /// <summary>
        /// Checks if the password passes all criteria.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <param name="message">Outputted list of validation messages.</param>
        /// <returns>Boolean indicating validity. True->Valid.</returns>
        bool IsPasswordValid(string password, out string message);
    }
}
