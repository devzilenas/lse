using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LinkShareEasy.Lib
{
    public sealed class ExceptionUtility
    {
        private ExceptionUtility() { }

        private static string CreateMessage(Exception e, string source)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0}", DateTime.Now));
            if (e.InnerException != null)
            {
                sb.Append("Inner exception type:");
                sb.AppendLine(e.InnerException.GetType().ToString());
                sb.Append("Inner exception: ");
                sb.AppendLine(e.InnerException.Message);
                sb.Append("Inner source: ");
                sb.AppendLine(e.InnerException.Source);

                if (e.InnerException.StackTrace != null)
                {
                    sb.AppendLine("Inner stack trace:");
                    sb.AppendLine(e.InnerException.StackTrace);
                }
            }

            sb.Append("Exception type: ");
            sb.AppendLine(e.GetType().ToString());
            sb.AppendLine("Exception: " + e.Message);
            sb.AppendLine("Source: " + e.Source);
            if (e.StackTrace != null)
            {
                sb.AppendLine("Stack trace: ");
                sb.AppendLine(e.StackTrace);
                sb.AppendLine();
            }

            return sb.ToString(); 
        }

        public static void LogToEventLog(Exception e, string source)
        {
            if (!EventLog.SourceExists("Ephemeral links"))
            {
                EventLog.CreateEventSource("Ephemeral links", "EphemeralLinkWebLog");
            }

            EventLog.WriteEntry("Ephemeral links" , CreateMessage(e, source), EventLogEntryType.Warning, 234); 
        }

    }
}