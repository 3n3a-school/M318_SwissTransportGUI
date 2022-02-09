using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace SwissTransportGUI.Controller
{
    public class RegexHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidSearchQuery(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return false;

            string[] _badChars = new string[] {"@", "*", "#", "\"", "+", "¦", "§", "°", "&", "%", "/", "=", "?", "`", "'", "^", "$", "£" };
            bool _containsBadChar = false;
            foreach (string badChar in _badChars)
            {
                if (searchQuery.Contains(badChar))
                    _containsBadChar = true;
            }
            
            if (_containsBadChar)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
