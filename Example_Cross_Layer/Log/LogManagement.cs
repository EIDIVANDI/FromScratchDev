using System.Configuration;

namespace Example_Cross_Layer.Log
{

    public class LogManagement
    {
        const string _paramName = "Logging";
        public static bool IsLoggingValide;
        static bool _IslogInitialized;
        static object _Lock = new object();

        public bool LogEnabled()
        {
            if (!_IslogInitialized && !IsLoggingValide)
            {
                lock (_Lock)
                {
                    if (!_IslogInitialized && !IsLoggingValide)
                    {
                        return bool.TryParse(ConfigurationSettings.AppSettings["Loging"], out IsLoggingValide);
                    }
                }
            }
            return IsLoggingValide;
        }

        public virtual bool SourceExistes()
        {
            if (!_IslogInitialized)
            {
                if (LogEnabled())
                {
                    _IslogInitialized = true;
                }
            }
            return _IslogInitialized;
         
        }

        public virtual void WriteLog(string msg) { }
    }
}
