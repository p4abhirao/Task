using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using TaskApplication.Models;

namespace TaskApplication.Controllers
{
	public class TaskController : Controller
	{
		// GET: Task
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult TaskCreate()
		{
			try
			{
				List<SelectListItem> PriorityList = new List<SelectListItem>();

				PriorityList.Add(new SelectListItem { Text = "P1", Value = "1" });
				PriorityList.Add(new SelectListItem { Text = "P2", Value = "2" });
				PriorityList.Add(new SelectListItem { Text = "P3", Value = "3" });
				ViewData["PriorityList"] = (IEnumerable<SelectListItem>)PriorityList;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return View();
		}

        /// <summary>
        /// Get Task list
        /// </summary>
        /// <returns></returns>
		public ActionResult TaskList()
		{
            string result = string.Empty, uri = "", sMethod = "POST";
            uri = System.Configuration.ConfigurationManager.AppSettings["APIUrl"] + "api/Task/TaskList?sText=0";
            var lTask = new List<Task>();

            //request object
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = sMethod;
            req.ContentType = "application/json";

           
                HttpWebResponse httpResponse = (HttpWebResponse)req.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    // store response body
                    result = streamReader.ReadToEnd();

                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result)))
                    {
                        //converting json to class
                        var serializer = new DataContractJsonSerializer(lTask.GetType());
                        lTask = serializer.ReadObject(stream) as List<Task>;

                    }

                    httpResponse.Close();
                }
                
			return View(lTask);
		}
	}
}