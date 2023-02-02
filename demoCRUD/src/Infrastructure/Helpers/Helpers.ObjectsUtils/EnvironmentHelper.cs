using System;

namespace Helpers.ObjectsUtils
{
    /// <summary>
    /// EnvironmentHelper
    /// </summary>
    public class EnvironmentHelper
    {
        /// <summary>
        ///   GetCountryOrDefault
        /// </summary>
        /// <param name="defaultCountry"></param>
        /// <returns></returns>
        public static string GetCountryOrDefault(string defaultCountry)
        {
            const string COUNTRY = "COUNTRY";
            string country = GetVariable(COUNTRY);

            return string.IsNullOrEmpty(country) ? defaultCountry : country;
        }

        /// <summary>
        ///   GetSubDomainOrDefault
        /// </summary>
        /// <param name="defaultSubDomain"></param>
        /// <returns></returns>
        public static string GetSubDomainOrDefault(string defaultSubDomain)
        {
            const string SUBDOMAIN = "SUBDOMAIN";
            string subDomain = GetVariable(SUBDOMAIN);

            return string.IsNullOrEmpty(subDomain) ? defaultSubDomain : subDomain;
        }

        /// <summary>
        ///   GetVariable
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}