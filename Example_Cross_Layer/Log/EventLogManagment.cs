using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Cross_Layer.Log
{
    public sealed class EventLogManagment : LogManagement
    {
        public static string SourceLogName;
        private static object _Lock = new object();
        static EventLogManagment()
        {
            if (string.IsNullOrWhiteSpace(SourceLogName))
            {
                lock (_Lock)
                {
                    if (string.IsNullOrWhiteSpace(SourceLogName))
                    {
                        SourceLogName = ConfigurationSettings.AppSettings["LogEventSource"];
                        IsLoggingValide = (string.IsNullOrWhiteSpace(SourceLogName));
                    }
                }
            }
        }

        public override bool SourceExistes()
        {

            if (!string.IsNullOrWhiteSpace(SourceLogName))
            {
                base.SourceExistes();
                return EventLog.SourceExists(SourceLogName);
            }
            return false;
        }

        public override void WriteLog(string msg)
        {
            if (SourceExistes())
            {
                base.WriteLog(msg);
                EventLog.WriteEntry(SourceLogName, msg);
            }

        }
    }
}
