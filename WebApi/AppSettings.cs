using System.Configuration;

namespace WebAPI
{
    /// <summary>
    /// Class AppSettings.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Gets the hr web API address.
        /// </summary>
        /// <value>The hr web API address.</value>
        public static string HrApiEndpoint => ConfigurationManager.AppSettings["HrApiEndpoint"];
        /// <summary>
        /// Gets the dictionaries API endpoint.
        /// </summary>
        /// <value>
        /// The dictionaries API endpoint.
        /// </value>
        public static string DictionariesApiEndpoint => ConfigurationManager.AppSettings["DictionariesApiEndpoint"];
    }
}