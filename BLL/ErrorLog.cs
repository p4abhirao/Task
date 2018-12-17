using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class ErrorLog
	{
		public static string ErrorLogFolderPath = string.Empty;

		public static long ErrorCount
		{
			get;
			private set;
		}

		static string errorFilePath = string.Empty;

		private static void GenerateErrorFileName()
		{
			if (string.IsNullOrEmpty(ErrorLogFolderPath))
			{
				ErrorLogFolderPath = AppDomain.CurrentDomain.BaseDirectory + "logs\\";
			}

			if (string.IsNullOrEmpty(errorFilePath))
			{
				errorFilePath = ErrorLogFolderPath + string.Format("log_{0}.html", DateTime.Now.ToString("MMM_dd_yyyy_hhmmtt"));
			}
		}

		public static void WriteLog(string className, string eventName, string shortMessage, string errorDescription, string queryCondtions)
		{
			ErrorCount = ErrorCount + 1;
			if (ErrorCount >= long.MaxValue)
			{
				ErrorCount = 1;
			}
			className = string.Format("<a name=\"{0}\" href=\"#{0}\">{0}.{1}</a>", ErrorCount, className);
			_writeLog(className, eventName, shortMessage, errorDescription, queryCondtions);
		}

		public static void WriteLog(string className, string eventName, Exception ex, string queryCondtions)
		{
			WriteLog(className, eventName, ex.Message, ex.StackTrace, queryCondtions);
		}

		private static void _writeLog(string className, string eventName, string shortMessage, string errorDescription, string queryCondtions)
		{
			try
			{
				GenerateErrorFileName();

				bool isNew = false;

				if (!System.IO.Directory.Exists(ErrorLogFolderPath))
				{
					System.IO.Directory.CreateDirectory(ErrorLogFolderPath);
				}

				if (!System.IO.File.Exists(errorFilePath))
				{
					isNew = true;
				}

				using (System.IO.StreamWriter oSW = new System.IO.StreamWriter(new System.IO.FileStream(errorFilePath, System.IO.FileMode.Append, System.IO.FileAccess.Write)))
				{
					StringBuilder strMessage = new StringBuilder();

					if (isNew)
					{
						strMessage.Append("<table border='1' cellspacing='1' width='100%'>");
						strMessage.Append("<tr>");
						strMessage.AppendFormat("<td>{0}</td>", "Date");
						strMessage.AppendFormat("<td>{0}</td>", "Time");
						strMessage.AppendFormat("<td>{0}</td>", "Source");
						strMessage.AppendFormat("<td>{0}</td>", "Event");
						strMessage.AppendFormat("<td>{0}</td>", "Message");
						strMessage.AppendFormat("<td>{0}</td>", "StackTrace");
						strMessage.AppendFormat("<td>{0}</td>", "Condition");
						strMessage.Append("</tr>");
					}
					strMessage.Append("<tr>");
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", DateTime.Now.ToShortDateString());
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", DateTime.Now.ToLongTimeString());
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", className);
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", eventName);
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", shortMessage);
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", errorDescription);
					strMessage.AppendFormat("<td valign=\"top\">{0}&#160;</td>", queryCondtions);
					strMessage.Append("</tr>");
					//strMessage.Append("\"" + DateTime.Now.ToShortDateString() + "\",\"" + DateTime.Now.ToLongTimeString() + "\",\"" + className + "\",\"" + shortMessage + "\",\"" + errorDescription + "\",\"" + queryCondtions + "\"");
					oSW.WriteLine("");
					oSW.WriteLine(strMessage);
					oSW.Flush();
					oSW.Close();
				}
			}
			catch { }
		}
	}
}
