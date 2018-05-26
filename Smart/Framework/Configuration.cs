using System.Configuration;

namespace demo.framework {
    
    public static class Configuration {
        //Settings
        private const string Timeout = "Timeout";
        private const string BaseUrl = "BaseUrl";
        private const string Browser = "Browser";
        private const string UrlApi = "UrlApi";


        private static string GetParameterValue(string key) {
            return ConfigurationManager.AppSettings.Get(key);
        }

        //============================================== Settings ====================================================
        public static string GetTimeout() {
            return GetParameterValue(Timeout);
        }

        public static string GetBaseUrl()
        {
            return GetParameterValue(BaseUrl);
        }

        public static string GetBrowser()
        {
            return GetParameterValue(Browser);
        }

        public static string GetUrlApi()
        {
            return GetParameterValue(UrlApi);
        }
    }
}