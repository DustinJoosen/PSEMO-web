using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PasswordPolicyService : IPasswordPolicyService
    {
        private static int _minLength = 6;
        private static int _amountCapitalized = 1;
        private static int _amountNumbers = 1;
        private static int _amountSpecChars = 1;

        /// <summary>
        /// Checks if the password passes all criteria.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <param name="message">Outputted list of validation messages.</param>
        /// <returns>Boolean indicating validity. True->Valid.</returns>
        public bool IsPasswordValid(string password, out string message)
        {
            message = string.Empty;

            if (password.Length < _minLength)
            {
                message = $"Wachtwoord moet tenminste {_minLength} tekens lang zijn";
                return false;
            }

            if (!CapitalLettersMatch(password))
            {
                message = $"Wachtwoord moet tenminste {_amountCapitalized} hoofdletters hebben";
                return false;
            }

            if (!NumberMatch(password))
            {
                message = $"Wachtwoord moet tenminste {_amountNumbers} nummers hebben";
                return false;
            }

            if (!SpecCharsMatch(password))
            {
                message = $"Wachtwoord moet tenminste {_amountSpecChars} speciale characters hebben";
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks whether the password contains the specified amount of special characters.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>Boolean indicating if the password passes the check.</returns>
        private static bool SpecCharsMatch(string password)
        {
            string pattern = $@"^.*([\W_].*){{{_amountSpecChars}}}.*$";
            return Regex.IsMatch(password, pattern);
        }

        /// <summary>
        /// Checks whether the password contains the specified amount of numbers.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>Boolean indicating if the password passes the check.</returns>
        private static bool NumberMatch(string password)
        {
            string pattern = $@"^.*(\d.*){{{_amountNumbers}}}.*$";
            return Regex.IsMatch(password, pattern);
        }

        /// <summary>
        /// Checks whether the password contains the specified amount of capitalized characters.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>Boolean indicating if the password passes the check.</returns>
        private static bool CapitalLettersMatch(string password)
        {
            string pattern = $@"^.*([A-Z].*){{{_amountCapitalized}}}.*$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
