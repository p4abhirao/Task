using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Response
{
	/// <summary>
	/// response class for Task
	/// </summary>
	public class ResTaskData : IResponseFormat
	{
		public int Success { get; set; }
		public int StatusCode { get; set; }
		public string StatusDesc { get; set; }

		public Task cTask { get; set; }
		public List<Task> listTaskinfo { get; set; }

		public ResTaskData()
		{
			cTask = new Task();
			listTaskinfo = new List<Task>();
		}
	}
}